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
        Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdAsync(int groupId);
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAsync(DateTime date);
    }
}