using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;
using EducationProcess.ApiClient.Models.Groups.Responses;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;
using EducationProcess.HandyDesktop.Services;
using EducationProcess.HandyDesktop.Tools.Extension;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class ScheduleEditorViewModel : ViewModelBase
    {
        private readonly IScheduleDisciplineService _scheduleDisciplineService;
        private readonly IGroupService _groupService;
        private readonly IFixedDisciplineService _fixedDisciplineService;
        private ScheduleDiscipline _semesterDisciplineCurrent;

        public ScheduleEditorViewModel(IScheduleDisciplineService scheduleDisciplineService, IGroupService groupService, IFixedDisciplineService fixedDisciplineService)
        {
            _scheduleDisciplineService = scheduleDisciplineService;
            _groupService = groupService;
            _fixedDisciplineService = fixedDisciplineService;

            FixedDisciplineCollection = new ObservableCollection<FixedDiscipline>();
            ScheduleDisciplineCollection = new ObservableCollection<ScheduleForDayModel>();
            GroupCollection = new ObservableCollection<Group>();
            ScheduleInfoCollection = new ObservableCollection<ScheduleForDayModel>();

            DateTime date = new DateTime(2020, 05, 19);

            Task.Run(() => GetCurrentGroups(date));
            Task.Run(() => GetScheduleInfoCollection(date));
            Task.Run(() => GetFixedDisciplinesByGroupCollection(1)).ContinueWith(_ => GetScheduleForGroup(1));
        }


        public ObservableCollection<ScheduleForDayModel> ScheduleDisciplineCollection { get; set; }
        public ObservableCollection<Group> GroupCollection { get; set; }
        public ObservableCollection<ScheduleForDayModel> ScheduleInfoCollection { get; set; }
        public ObservableCollection<FixedDiscipline> FixedDisciplineCollection { get; set; }

        public RelayCommand<LessonModel> UpdatePairLessonsCommand => new(UpdatePairLessons);
        public RelayCommand CheckCommand => new(Check);

        private async void Check()
        {
            List<ScheduleDiscipline> scheduleForWeek = new List<ScheduleDiscipline>();
            foreach (var dayLessons in ScheduleDisciplineCollection.GroupBy(x => x.Date))
            {
                foreach (var pairDisciplines in dayLessons.SelectMany(x => x.Lessons).Where(x => x.Disciplines.Count > 0).GroupBy(x => x.PairNumber))
                {
                    foreach (var lesson in pairDisciplines.SelectMany(x => x.Disciplines).Where(x => x.FixedDiscipline is not null && x.FixedDiscipline.FixedDisciplineId > 0))
                    {
                        ScheduleDiscipline scheduleDiscipline = new ScheduleDiscipline()
                        {
                            FixedDisciplineId = lesson.FixedDiscipline.FixedDisciplineId,
                            Date = dayLessons.Key.Date,
                            PairNumber = pairDisciplines.Key,
                            IsEvenPair = lesson.IsEvenPair, 
                            CreatedByEmployeeId = 1,
                            CreatedAt = DateTime.Now,
                            ModifiedByEmployeeId = 1,
                            ModifiedAt = DateTime.Now
                        };
                        scheduleForWeek.Add(scheduleDiscipline);
                    }
                }
                return;
            }
        }

        private async void UpdatePairLessons(LessonModel lessonModel)
        {
            await Task.Run(() =>
            {
                if (lessonModel.Disciplines.Count >= 2)
                {
                    ScheduleDiscipline scheduleDiscipline = lessonModel.Disciplines.First();
                    scheduleDiscipline.IsEvenPair = null;
                    lessonModel.Disciplines = new List<ScheduleDiscipline>(new[] { scheduleDiscipline });
                }
                else
                {
                    ScheduleDiscipline scheduleDisciplineEven = lessonModel.Disciplines.First();
                    scheduleDisciplineEven.IsEvenPair = true;
                    ScheduleDiscipline scheduleDisciplineNotEven = new ScheduleDiscipline()
                    {
                        IsEvenPair = false,
                        Date = scheduleDisciplineEven.Date,
                        PairNumber = scheduleDisciplineEven.PairNumber
                    };
                    lessonModel.Disciplines =
                        new List<ScheduleDiscipline>(new[] { scheduleDisciplineEven, scheduleDisciplineNotEven });
                }
            });
        }

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

        private async Task GetScheduleForGroup(int groupId)
        {
            ScheduleDiscipline[] scheduleDisciplines;
            try
            {
                scheduleDisciplines = await _scheduleDisciplineService.GetCurrentScheduleByDateAsync(new DateTime(2020, 05, 19));
                scheduleDisciplines = scheduleDisciplines.Where(x => x.FixedDiscipline.GroupId == groupId && x.Date.Month == 6).ToArray();
            }
            catch (Exception e)
            {
                Growl.Error(e.Message);
                throw;
            }

            foreach (var scheduleDiscipline in scheduleDisciplines)
            {
                scheduleDiscipline.FixedDiscipline =
                    FixedDisciplineCollection.FirstOrDefault(x =>
                        x.FixedDisciplineId == scheduleDiscipline.FixedDisciplineId);
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

        private async Task GetCurrentGroups(DateTime date)
        {
            Group[] groups;
            try
            {
                groups = await _groupService.GetAllCurrentGroupsByDate(date);
            }
            catch (Exception e)
            {
                Growl.Error(e.Message);
                throw;
            }

            foreach (var group in groups.OrderBy(x => x.CourseNumber))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    GroupCollection.Add(group);
                }), DispatcherPriority.Send);
            }
        }

        private async Task GetFixedDisciplinesByGroupCollection(int groupId)
        {
            FixedDiscipline[] fixedDisciplines;
            try
            {
                fixedDisciplines = await _fixedDisciplineService.GetAllByGroupIdAsync(groupId);
            }
            catch (Exception e)
            {
                Growl.Error(e.Message);
                throw;
            }

            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                FixedDisciplineCollection.Add(new FixedDiscipline());
            }), DispatcherPriority.Send);
            foreach (var fixedDiscipline in fixedDisciplines.Where(x => x.IsAgreed is true))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FixedDisciplineCollection.Add(fixedDiscipline);
                }), DispatcherPriority.Send);
            }
        }
    }
}