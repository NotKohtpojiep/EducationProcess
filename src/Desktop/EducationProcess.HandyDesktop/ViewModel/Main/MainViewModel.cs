using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Properties.Langs;
using EducationProcess.HandyDesktop.Service;
using EducationProcess.HandyDesktop.Tools;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private object _contentTitle;
        private object _subContent;

        private readonly DataService _dataService;

        public MainViewModel(DataService dataService)
        {
            _dataService = dataService;

            UpdateMainContent();
            UpdateLeftContent();
        }

        public SideMenuModel SideMenuCurrent { get; private set; }

        public object SubContent
        {
            get => _subContent;
            set => Set(ref _subContent, value);
        }

        public object ContentTitle
        {
            get => _contentTitle;
            set => Set(ref _contentTitle, value);
        }

        public ObservableCollection<HeadSideMenuModel> HeadSideMenuModels { get; set; }

        public RelayCommand<SelectionChangedEventArgs> SwitchDemoCmd => new(SwitchDemo);

        public RelayCommand GlobalShortcutInfoCmd => new(() => Growl.Info("Global Shortcut Info"));

        public RelayCommand GlobalShortcutWarningCmd => new(() => Growl.Warning("Global Shortcut Warning"));


        private void UpdateMainContent()
        {
            Messenger.Default.Register<object>(this, MessageToken.LoadShowContent, obj =>
            {
                if (SubContent is IDisposable disposable)
                {
                    disposable.Dispose();
                }
                SubContent = obj;
            }, true);
        }

        private void UpdateLeftContent()
        {
            Messenger.Default.Register<object>(this, MessageToken.ClearLeftSelected, obj =>
            {
                SideMenuCurrent = null;
            });
            Messenger.Default.Register<object>(this, MessageToken.LangUpdated, obj =>
            {
                if (SideMenuCurrent == null) return;
                ContentTitle = LangProvider.GetLang(SideMenuCurrent.Name);
            });

            //load items
            HeadSideMenuModels = new ObservableCollection<HeadSideMenuModel>();

            Task.Run(() =>
            {
                foreach (var item in _dataService.GetDemoInfo("some"))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        HeadSideMenuModels.Add(item);
                    }), DispatcherPriority.ApplicationIdle);
                }
            });
        }

        private void SwitchDemo(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            if (e.AddedItems[0] is SideMenuModel item)
            {
                if (Equals(SideMenuCurrent, item)) return;
                SwitchDemo(item);
            }
        }

        private void SwitchDemo(SideMenuModel item)
        {
            SideMenuCurrent = item;
            ContentTitle = LangProvider.GetLang(item.Name);
            var obj = AssemblyHelper.ResolveByKey(item.TargetCtlName);
            var ctl = obj ?? AssemblyHelper.CreateInternalInstance($"UserControl.{item.TargetCtlName}");
            Messenger.Default.Send(ctl, MessageToken.LoadShowContent);
        }
    }
}