using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.Audiences.Responses;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;
using EducationProcess.HandyDesktop.Services;
using EducationProcess.HandyDesktop.Tools.Extension;
using GalaSoft.MvvmLight;
using HandyControl.Controls;

namespace EducationProcess.HandyDesktop.ViewModel
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


        private async Task<LessonModel[]> GetEmptyLessons(LessonModel[] lessons)
        {
            List<LessonModel> lessonList = new List<LessonModel>();

            await Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (lessons.FirstOrDefault(x => x.PairNumber == i) is null)
                    {
                        lessonList.Add(new LessonModel()
                        { PairNumber = i, LessonCells = new LessonCellModel[] { new() } });
                    }
                }

            });

            return lessonList.ToArray();
        }

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

            List<ScheduleForDayModel> schedule = new List<ScheduleForDayModel>();

            foreach (var day in scheduleDisciplines.GroupBy(x => x.Date.Day).OrderBy(x => x.Key))
            {
                List<LessonModel> lessonList = new List<LessonModel>();
                foreach (var lesson in day.GroupBy(x => x.PairNumber))
                {
                    LessonCellModel[] lessonCells = lesson.Select(x => new LessonCellModel
                    {
                        SubNumber = x.IsEvenPair is null ? "" : (bool)x.IsEvenPair ? "чс." : "зн.",
                        Audience = x.Audience is null ? "" : x.Audience.Number,
                        Discipline = x.FixedDiscipline.SemesterDiscipline.Discipline.Name,
                        FixedFor = x.FixedDiscipline.Group.Name
                    }).OrderByDescending(x => x.SubNumber).ToArray();

                    if (lessonCells.Length == 1 && lesson.First().IsEvenPair is not null)
                    {
                        lessonCells = new[]
                        {
                            lessonCells[0], new() {SubNumber = (bool) !lesson.First().IsEvenPair ? "чс." : "зн."}
                        }.OrderByDescending(x => x.SubNumber).ToArray();
                    }

                    lessonList.Add(new LessonModel()
                    {
                        PairNumber = lesson.First().PairNumber,
                        LessonCells = lessonCells
                    });
                }

                LessonModel[] emptyLessons = await GetEmptyLessons(lessonList.ToArray());
                lessonList.AddRange(emptyLessons);

                ScheduleForDayModel scheduleForDay = new ScheduleForDayModel()
                {
                    DayOfWeek = day.First().Date.DayOfWeek,
                    Lessons = lessonList.OrderBy(x => x.PairNumber).ToArray()
                };
                schedule.Add(scheduleForDay);
            }

            for (int i = 1; i <= 5; i++)
            {
                if (scheduleDisciplines.FirstOrDefault(x => (int)x.Date.DayOfWeek == i) is null)
                {
                    schedule.Add(new() { DayOfWeek = (DayOfWeek)i, Lessons = await GetEmptyLessons(new LessonModel[] { }) });
                }
            }

            foreach (var scheduleForDay in schedule.OrderBy(x => x.DayOfWeek))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ScheduleDisciplineCollection.Add(scheduleForDay);
                }), DispatcherPriority.Send);
            }
        }
    }
}