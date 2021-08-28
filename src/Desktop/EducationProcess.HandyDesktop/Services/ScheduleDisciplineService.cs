using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;
using EducationProcess.HandyDesktop.Tools.Extension;

namespace EducationProcess.HandyDesktop.Services
{
    public class ScheduleDisciplineService : IScheduleDisciplineService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public ScheduleDisciplineService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<ScheduleDiscipline[]> GetCurrentScheduleByDateAsync(DateTime date)
        {
            return await _educationProcessClient.Schedules.GetAllScheduleDisciplinesForWeekByDateWithIncludeAsync(date);
        }

        public async Task<ScheduleDiscipline[]> GetCurrentScheduleForTeacherAsync(int teacherId)
        {
            return await _educationProcessClient.Schedules.GetCurrentScheduleDisciplinesForTeacherWithIncludeAsync(teacherId);
        }

        public async Task<ScheduleDiscipline[]> GetCurrentScheduleForGroupAsync(int groupId)
        {
            return await _educationProcessClient.Schedules.GetCurrentScheduleDisciplinesForGroupWithIncludeAsync(groupId);
        }



        /// <summary>
        /// Получение дисциплин без данных за день на основе имеющихся
        /// </summary>
        /// <param name="lessons"></param>
        /// <returns>
        /// Пустые дисциплины вплоть до 5 пары. Если у дисциплины пара раз в две недели, для другой половины выдается пустая дисциплина.
        /// </returns>
        public async Task<LessonModel[]> GetEmptyLessonsForDay(LessonModel[] lessons)
        {
            List<LessonModel> lessonList = new List<LessonModel>();

            await Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (lessons.FirstOrDefault(x => x.PairNumber == i) is null)
                    {
                        lessonList.Add(new LessonModel(new[] { new ScheduleDiscipline { PairNumber = i } }, FixedForInfo.Group));
                    }
                }
            });

            return lessonList.ToArray();
        }

        private async Task<ScheduleForDayModel> GetLessonsForDay(ScheduleDiscipline[] lessonsForDay, FixedForInfo fixedFor)
        {
            List<LessonModel> lessonList = new List<LessonModel>();
            await Task.Run(() =>
            {
                foreach (var pairLessons in lessonsForDay.GroupBy(x => x.PairNumber))
                {
                    lessonList.Add(new LessonModel(pairLessons.ToArray(), fixedFor));
                }
            });

            LessonModel[] emptyLessons = await GetEmptyLessonsForDay(lessonList.ToArray());
            lessonList.AddRange(emptyLessons);

            return new ScheduleForDayModel()
            {
                Date = lessonsForDay.First().Date,
                Lessons = lessonList.OrderBy(x => x.PairNumber).ToArray()
            };
        }

        public async Task<ScheduleForDayModel[]> GetScheduleForWeek(ScheduleDiscipline[] scheduleDisciplines, FixedForInfo fixedFor)
        {
            List<ScheduleForDayModel> scheduleForWeek = new List<ScheduleForDayModel>();

            foreach (var dayLessons in scheduleDisciplines.GroupBy(x => x.Date.Day))
            {
                scheduleForWeek.Add(await GetLessonsForDay(dayLessons.ToArray(), fixedFor));
            }

            DateTime monday = DateTime.Now.Date.StartOfWeek(DayOfWeek.Monday);
            if (scheduleDisciplines.Length > 0)
                scheduleDisciplines.First().Date.StartOfWeek(DayOfWeek.Monday);

            for (int i = 1; i <= 5; i++)
            {
                if (scheduleDisciplines.FirstOrDefault(x => (int)x.Date.DayOfWeek == i) is null)
                {
                    scheduleForWeek.Add(new ScheduleForDayModel
                    { Date = monday.AddDays(i - 1), Lessons = await GetEmptyLessonsForDay(new LessonModel[] { }) });
                }
            }

            return scheduleForWeek.ToArray();
        }

        public async Task<GroupScheduleModel> GetScheduleForGroup(ScheduleDiscipline[] scheduleDisciplines)
        {
            string groupName = scheduleDisciplines.First().FixedDiscipline.Group.Name;
            ScheduleForDayModel[] scheduleForWeek = await GetScheduleForWeek(scheduleDisciplines, FixedForInfo.Teacher);

            return new GroupScheduleModel { GroupName = groupName, Schedule = scheduleForWeek.OrderBy(x => x.Date).ToArray() };
        }
    }
}
