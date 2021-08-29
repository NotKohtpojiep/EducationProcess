using System.Collections.ObjectModel;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Model;
using GalaSoft.MvvmLight.Command;
using EducationProcess.HandyDesktop.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class EducationPlanMainViewModel : ViewModelBase
    {
        private TabItemModel _tabControlCurrent;

        public EducationPlanMainViewModel()
        {
            TabControlsCollection = new ObservableCollection<TabItemModel>();

            var tabItem = new TabItemModel
            {
                Header = "EducationPlanMenu",
                Content = AssemblyHelper.CreateInternalInstance($"UserControls.EducationPlanMenuView")
            };
            TabControlsCollection.Add(tabItem);
            TabControlCurrent = tabItem;

            Messenger.Default.Register<TabItemModel>(this, MessageToken.NewEducationPlanTabContent, AddNewTabControlItem);
        }

        public TabItemModel TabControlCurrent
        {
            get => _tabControlCurrent;
            set => Set(ref _tabControlCurrent, value);
        }

        public ObservableCollection<TabItemModel> TabControlsCollection { get; set; }

        public RelayCommand<TabItemModel> AddViewCommand => new(AddNewTabControlItem);

        public RelayCommand AddEducationPlanViewCommand => new(AddNewEducationPlanMenuTabControlItem);

        private void AddNewTabControlItem(TabItemModel tabItemModel)
        {
            if (tabItemModel is null)
                return;

            TabControlsCollection.Add(tabItemModel);
            TabControlCurrent = tabItemModel;
        }

        private void AddNewEducationPlanMenuTabControlItem()
        {
            var view = AssemblyHelper.CreateInternalInstance($"UserControls.EducationPlanMenuView");
            TabItemModel tabItemModel = new TabItemModel
            {
                Header = "EducationPlanMenu",
                Content = view
            };
            AddNewTabControlItem(tabItemModel);
        }
    }
}