using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class EducationPlanDisciplinesMenuView : ViewModelBase
    {
        private IEducationPlanService _educationPlanService;
        private EducationPlan _educationPlanCurrent;
        private bool _dataGot;

        public EducationPlanDisciplinesMenuView(IEducationPlanService educationPlanService, EducationPlan educationPlan)
        {
            _educationPlanService = educationPlanService;
            SemesterDisciplineCollection = new ObservableCollection<SemesterDiscipline>();

            //Task.Run(GetAllEducationPlans).ContinueWith(obj => DataGot = SemesterDisciplineCollection.Count != 0);
        }

        public EducationPlan EducationPlanCurrent
        {
            get => _educationPlanCurrent;
            set => Set(ref _educationPlanCurrent, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<SemesterDiscipline> SemesterDisciplineCollection { get; set; }

        public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewEducationPlanTabContent));

        private async Task GetAllEducationPlans()
        {
        }
    }
}