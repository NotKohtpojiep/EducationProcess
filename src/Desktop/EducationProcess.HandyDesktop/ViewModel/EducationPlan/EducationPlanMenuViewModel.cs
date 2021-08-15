using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Model;
using EducationProcess.HandyDesktop.Service;
using EducationProcess.HandyDesktop.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class EducationPlanMenuViewModel : ViewModelBase
    {
        private readonly IEducationPlanService _educationPlanService;
        private EducationPlan _educationPlanSelected;
        private bool _dataGot;

        public EducationPlanMenuViewModel(IEducationPlanService educationPlanService)
        {
            _educationPlanService = educationPlanService;
            EducationPlanCollection = new ObservableCollection<EducationPlan>();

            Task.Run(GetAllEducationPlans).ContinueWith(obj => DataGot = EducationPlanCollection.Count != 0);
        }

        public EducationPlan EducationPlanSelected
        {
            get => _educationPlanSelected;
            set => Set(ref _educationPlanSelected, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<EducationPlan> EducationPlanCollection { get; set; }


        //public RelayCommand AddEducationPlanCommand => new(CreateSelectedEducationPlanTabControl);

        //public RelayCommand EditEducationPlanCommand => new(CreateSelectedEducationPlanTabControl);

        //public RelayCommand DeleteEducationPlanCommand => new(CreateSelectedEducationPlanTabControl);

        public RelayCommand ViewSelectedEducationPlanDisciplinesCommand => new(ViewSelectedEducationPlanDisciplines);

        //public RelayCommand ViewSelectedEducationPlanGroupsCommand => new(CreateSelectedEducationPlanTabControl);

        public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewEducationPlanTabContent));


        private void ViewSelectedEducationPlanDisciplines()
        {
            if (EducationPlanSelected is null)
            {
                Growl.Info("Выберите учебный план");
                return;
            }

            var view = AssemblyHelper.CreateInternalInstance($"UserControl.EducationPlanDisciplinesMenuView");
            ((FrameworkElement)view).DataContext = new EducationPlanDisciplinesMenuView(SimpleIoc.Default.GetInstance<IEducationPlanService>(), EducationPlanSelected);

            var tabItemModel = new TabItemModel()
            {
                Header = "EducationPlanDisciplineMenu",
                Content = view
            };
            Messenger.Default.Send(tabItemModel, MessageToken.NewEducationPlanTabContent);
        }

        private async Task GetAllEducationPlans()
        {
            EducationPlan[] educationPlans;
            try
            {
                educationPlans = await _educationPlanService.GetAllEducationPlans();
            }
            catch (SocketException e)
            {
                Growl.Error("Ошибка подключения к сети");
                throw;
            }
            catch (HttpRequestException e)
            {
                Growl.Fatal("Ошибка подключения к удаленному серверу");
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetType().Name + "  -  " + e.Message);
                throw;
            }

            foreach (var item in educationPlans)
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    EducationPlanCollection.Add(item);
                }), DispatcherPriority.Send);
            }
        }
    }
}