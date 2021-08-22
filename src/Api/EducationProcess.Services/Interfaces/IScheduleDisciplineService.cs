using System;
using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IScheduleDisciplineService
    {
        Task<ScheduleDiscipline> GetScheduleDisciplineByIdAsync(int scheduleDisciplineId);
        Task<ScheduleDiscipline> AddScheduleDisciplineAsync(ScheduleDiscipline newScheduleDiscipline);
        Task<ScheduleDiscipline[]> AddRangeScheduleDisciplineAsync(ScheduleDiscipline[] newScheduleDisciplines);
        Task<ScheduleDiscipline> UpdateScheduleDisciplineAsync(ScheduleDiscipline newScheduleDiscipline);
        Task<ScheduleDiscipline[]> UpdateRangeScheduleDisciplineAsync(ScheduleDiscipline[] newScheduleDiscipline);
        Task DeleteScheduleDisciplineAsync(ScheduleDiscipline scheduleDiscipline);
        Task DeleteRangeScheduleDisciplineAsync(ScheduleDiscipline[] scheduleDisciplines);
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(int departmentId, DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(int teacherId, DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdWithIncludeAsync(int groupId);

    }
}