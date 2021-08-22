using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Requests;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface ISchedulesClient
    {
        Task<ScheduleDiscipline> GetScheduleDisciplineAsync(int scheduleDisciplineId);
        Task<ScheduleDisciplineReplacement> GetScheduleDisciplineReplacementAsync(int scheduleDisciplineReplacementId);
        Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesAsync();
        Task<ScheduleDisciplineReplacement[]> GetAllScheduleDisciplineReplacementsAsync();

        Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesForWeekByDateWithIncludeAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetCurrentScheduleDisciplinesForGroupWithIncludeAsync(int groupId);
        Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesForWeekByDateAndDepartmentWithIncludeAsync(int departmentId, DateTime date);
        Task<ScheduleDiscipline[]> GetCurrentScheduleDisciplinesForTeacherWithIncludeAsync(int teacherId);

        Task<ScheduleDiscipline> CreateScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline);
        Task<ScheduleDisciplineReplacement> CreateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement);
        Task<ScheduleDiscipline[]> CreateScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines);
        Task<ScheduleDisciplineReplacement[]> CreateScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements);

        Task<ScheduleDiscipline> UpdateScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline);
        Task<ScheduleDisciplineReplacement> UpdateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement);
        Task<ScheduleDiscipline[]> UpdateScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines);
        Task<ScheduleDisciplineReplacement[]> UpdateScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements);

        Task DeleteScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline);
        Task DeleteScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement);
        Task DeleteScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines);
        Task DeleteScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements);
    }
}