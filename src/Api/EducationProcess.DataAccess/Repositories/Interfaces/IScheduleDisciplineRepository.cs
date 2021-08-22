using System;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IScheduleDisciplineRepository : IRepositoryBase<ScheduleDiscipline>
    {
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(int departmentId, DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(int teacherId, DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdWithIncludeAsync(int groupId);
    }
}