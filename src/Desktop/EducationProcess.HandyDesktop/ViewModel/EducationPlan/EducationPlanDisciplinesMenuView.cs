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
using EducationProcess.HandyDesktop.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class EducationPlanDisciplinesMenuView : ViewModelBase
    {
        private readonly IEducationPlanSemesterDisciplineService _educationPlanSemesterDisciplineService;
        private SemesterDiscipline _semesterDisciplineCurrent;
        private bool _dataGot;

        public EducationPlanDisciplinesMenuView(IEducationPlanSemesterDisciplineService educationPlanSemesterDisciplineService, EducationPlan educationPlan)
        {
            _educationPlanSemesterDisciplineService = educationPlanSemesterDisciplineService;

            SemesterDisciplineCollection = new ObservableCollection<SemesterDiscipline>();

            Task.Run(() => GetAllSemesterDisciplinesByEducationPlanId(educationPlan.EducationPlanId))
                .ContinueWith(obj => DataGot = SemesterDisciplineCollection.Count != 0);
        }

        public SemesterDiscipline SemesterDisciplineCurrent
        {
            get => _semesterDisciplineCurrent;
            set => Set(ref _semesterDisciplineCurrent, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<SemesterDiscipline> SemesterDisciplineCollection { get; set; }

        public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewEducationPlanTabContent));

        private async Task GetAllSemesterDisciplinesByEducationPlanId(int educationPlanId)
        {
            EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines;
            try
            {
                educationPlanSemesterDisciplines =
                    await _educationPlanSemesterDisciplineService.GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithInclude(educationPlanId);
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

            foreach (var item in educationPlanSemesterDisciplines)
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    SemesterDisciplineCollection.Add(item.SemesterDiscipline);
                }), DispatcherPriority.Send);
            }
        }
    }
}