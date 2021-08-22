using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.DataAccess.Repositories
{
    public class ScheduleDisciplineRepository : RepositoryBase<ScheduleDiscipline>, IScheduleDisciplineRepository
    {
        private readonly EducationProcessContext _context;

        public ScheduleDisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }

        
        public async Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(int departmentId, DateTime date)
        {
            date = AddDaysToSunday(date);

            bool isFirstHalfYear = date.Month / 7.0 < 1;

            ScheduleDiscipline[] scheduleDisciplines = await _context.ScheduleDisciplines
                .Where(x =>
                    x.FixedDiscipline.IsAgreed == true &&
                    x.FixedDiscipline.SemesterDiscipline.Semester.Number == (date.Year - x.FixedDiscipline.Group.ReceiptYear + (isFirstHalfYear ? 0 : 1)) * 2 - (isFirstHalfYear ? 0 : 1) &&
                    x.Date <= date &&
                    x.FixedDiscipline.Group.DepartmentId == departmentId)
                .Include(x => x.Audience)
                .ThenInclude(x => x.AudienceType)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.Group)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.FixingEmployee)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ToArrayAsync();
         
            return await GetLastFixedDisciplinesForWeekAsync(scheduleDisciplines);
        }

        public async Task<ScheduleDiscipline[]> GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(int teacherId, DateTime date)
        {
            date = AddDaysToSunday(date);

            bool isFirstHalfYear = date.Month / 7.0 < 1;

            ScheduleDiscipline[] scheduleDisciplines = await _context.ScheduleDisciplines
                .Where(x =>
                    x.FixedDiscipline.IsAgreed == true &&
                    x.FixedDiscipline.SemesterDiscipline.Semester.Number == (date.Year - x.FixedDiscipline.Group.ReceiptYear + (isFirstHalfYear ? 0 : 1)) * 2 - (isFirstHalfYear ? 0 : 1) &&
                    x.Date <= date &&
                    x.FixedDiscipline.FixingEmployeeId == teacherId)
                .Include(x => x.Audience)
                .ThenInclude(x => x.AudienceType)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.Group)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.FixingEmployee)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ToArrayAsync();

            return await GetLastFixedDisciplinesForWeekAsync(scheduleDisciplines);
        }

        // Расписание всех групп по последней неделе каждой закрепленной дисциплины
        public async Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(DateTime date)
        {
            date = AddDaysToSunday(date);

            bool isFirstHalfYear = date.Month / 7.0 < 1;

            ScheduleDiscipline[] scheduleDisciplines = await _context.ScheduleDisciplines
                .Where(x =>
                    x.FixedDiscipline.IsAgreed == true &&
                    x.FixedDiscipline.SemesterDiscipline.Semester.Number == (date.Year - x.FixedDiscipline.Group.ReceiptYear + (isFirstHalfYear ? 0 : 1)) * 2 - (isFirstHalfYear ? 0 : 1) &&
                    x.Date <= date)
                .Include(x => x.Audience)
                .ThenInclude(x => x.AudienceType)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.Group)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.FixingEmployee)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ToArrayAsync();

            return await GetLastFixedDisciplinesForWeekAsync(scheduleDisciplines);
        }

        // Вывод расписания за неделю.
        // Если сегодня воскресенье, выдает расписание за следующую (если таковая будет)
        public async Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdWithIncludeAsync(int groupId)
        {
            DateTime date = DateTime.Now;
            if (date.DayOfWeek is DayOfWeek.Sunday)
                date = date.AddDays(7);
            date = AddDaysToSunday(date);

            bool isFirstHalfYear = date.Month / 7.0 < 1;

            ScheduleDiscipline[] scheduleDisciplines = await _context.ScheduleDisciplines
                .Where(x =>
                    x.FixedDiscipline.IsAgreed == true &&
                    x.FixedDiscipline.Group.GroupId == groupId &&
                    x.FixedDiscipline.SemesterDiscipline.Semester.Number == (date.Year - x.FixedDiscipline.Group.ReceiptYear + (isFirstHalfYear ? 0 : 1)) * 2 - (isFirstHalfYear ? 0 : 1) &&
                    x.Date <= date)
                .Include(x => x.Audience)
                .ThenInclude(x => x.AudienceType)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.Group)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.FixingEmployee)
                .Include(x => x.FixedDiscipline)
                .ThenInclude(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ToArrayAsync();

            return await GetLastFixedDisciplinesForWeekAsync(scheduleDisciplines);
        }

        private static async Task<ScheduleDiscipline[]> GetLastFixedDisciplinesForWeekAsync(ScheduleDiscipline[] scheduleDisciplines)
        {
            await Task.Run(() =>
            {
                CultureInfo myCI = new CultureInfo("ru-RU");
                Calendar myCal = myCI.Calendar;

                CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
                DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

                scheduleDisciplines = scheduleDisciplines.OrderByDescending(x => x.Date).ToArray();
                scheduleDisciplines = scheduleDisciplines.Where(x =>
                        myCal.GetWeekOfYear(x.Date, myCWR, myFirstDOW) ==
                        myCal.GetWeekOfYear(
                            scheduleDisciplines.FirstOrDefault(y => y.FixedDisciplineId == x.FixedDisciplineId).Date,
                            myCWR, myFirstDOW))
                    .ToArray();
            });
            return scheduleDisciplines;
        }

        private DateTime AddDaysToSunday(DateTime date)
        {
            if (date.DayOfWeek is not DayOfWeek.Sunday)
                date = date.AddDays(7 - (int)date.DayOfWeek);
            return date;
        }
    }
}