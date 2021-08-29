using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;
using EducationProcess.HandyDesktop.Services;
using EducationProcess.HandyDesktop.Tools.Extension;
using GalaSoft.MvvmLight;
using HandyControl.Controls;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly IScheduleDisciplineService _scheduleDisciplineService;
        private bool _dataGot;

        public ScheduleViewModel(IScheduleDisciplineService scheduleDisciplineService)
        {
            _scheduleDisciplineService = scheduleDisciplineService;
            GroupScheduleCollection = new ObservableCollection<GroupScheduleModel>();
            ScheduleInfoCollection = new ObservableCollection<ScheduleForDayModel>();

            DateTime date = new DateTime(2020, 05, 18);

            Task.Run(() => GetScheduleInfoCollection(date));
            Task.Run(() => GetCurrentScheduleByDate(date))
                .ContinueWith(_ => DataGot = GroupScheduleCollection.Count != 0);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<ScheduleForDayModel> ScheduleInfoCollection { get; set; }
        public ObservableCollection<GroupScheduleModel> GroupScheduleCollection { get; set; }


        private async Task GetScheduleInfoCollection(DateTime anyDateOfWeek)
        {
            DateTime monday = anyDateOfWeek.StartOfWeek(DayOfWeek.Monday);
            List<ScheduleForDayModel> scheduleForWeek = new List<ScheduleForDayModel>();
            for (int i = 1; i <= 5; i++)
            {
                ScheduleForDayModel scheduleForDay = new ScheduleForDayModel
                {
                    Date = monday.AddDays(i - 1),
                    Lessons = await _scheduleDisciplineService.GetEmptyLessonsForDay(new LessonModel[] { })
                };
                scheduleForWeek.Add(scheduleForDay);
            }

            foreach (var scheduleForDay in scheduleForWeek.OrderBy(x => x.Date))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ScheduleInfoCollection.Add(scheduleForDay);
                }), DispatcherPriority.Send);
            }
        }

        private async Task GetCurrentScheduleByDate(DateTime date)
        {
            ScheduleDiscipline[] scheduleDisciplines;
            try
            {
                scheduleDisciplines = await _scheduleDisciplineService.GetCurrentScheduleByDateAsync(date);
            }
            catch (Exception e)
            {
                Growl.Error(e.Message);
                throw;
            }

            List<GroupScheduleModel> groupScheduleCollection = new List<GroupScheduleModel>();
            foreach (var groupScheduleDisciplines in scheduleDisciplines.GroupBy(x => x.FixedDiscipline.GroupId))
            {
                groupScheduleCollection.Add(await _scheduleDisciplineService.GetScheduleForGroup(groupScheduleDisciplines.ToArray()));
            }

            foreach (var groupSchedule in groupScheduleCollection.OrderBy(x => x.GroupName))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    GroupScheduleCollection.Add(groupSchedule);
                }), DispatcherPriority.Send);
            }
        }
    }
}