using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;

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
    }
}
