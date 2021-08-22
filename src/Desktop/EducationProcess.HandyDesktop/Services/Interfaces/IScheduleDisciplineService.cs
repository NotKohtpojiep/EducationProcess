using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IScheduleDisciplineService
    {
        Task<ScheduleDiscipline[]> GetCurrentScheduleByDateAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetCurrentScheduleForTeacherAsync(int teacherId);
    }
}
