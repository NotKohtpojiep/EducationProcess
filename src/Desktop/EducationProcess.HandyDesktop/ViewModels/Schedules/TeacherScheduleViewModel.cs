using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;
using EducationProcess.HandyDesktop.Services;
using GalaSoft.MvvmLight;
using HandyControl.Controls;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class TeacherScheduleViewModel : ViewModelBase
    {
        private readonly IScheduleDisciplineService _scheduleDisciplineService;
        private ScheduleDiscipline _semesterDisciplineCurrent;
        private bool _dataGot;

        public TeacherScheduleViewModel(IScheduleDisciplineService scheduleDisciplineService)
        {
            _scheduleDisciplineService = scheduleDisciplineService;
            ScheduleDisciplineCollection = new ObservableCollection<ScheduleForDayModel>();

            Task.Run(() => GetTeacherScheduleByTeacherId(2))
                .ContinueWith(_ => DataGot = ScheduleDisciplineCollection.Count != 0);
        }

        public ScheduleDiscipline ScheduleDisciplineCurrent
        {
            get => _semesterDisciplineCurrent;
            set => Set(ref _semesterDisciplineCurrent, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<ScheduleForDayModel> ScheduleDisciplineCollection { get; set; }


        private async Task GetTeacherScheduleByTeacherId(int teacherId)
        {
            ScheduleDiscipline[] scheduleDisciplines;
            try
            {
                scheduleDisciplines = await _scheduleDisciplineService.GetCurrentScheduleForTeacherAsync(teacherId);
            }
            catch (Exception e)
            {
                Growl.Error(e.Message);
                throw;
            }

            ScheduleForDayModel[] scheduleForWeek = await _scheduleDisciplineService.GetScheduleForWeek(scheduleDisciplines, FixedForInfo.Group);

            foreach (var scheduleForDay in scheduleForWeek.OrderBy(x => x.Date))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ScheduleDisciplineCollection.Add(scheduleForDay);
                }), DispatcherPriority.Send);
            }
        }
    }
}