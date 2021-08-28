using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Requests;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class SchedulesClient : ISchedulesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal SchedulesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<ScheduleDiscipline> GetScheduleDisciplineAsync(int scheduleDisciplineId) =>
            await _httpFacade.Get<ScheduleDiscipline>($"ScheduleDisciplines/{scheduleDisciplineId}");

        public async Task<ScheduleDisciplineReplacement> GetScheduleDisciplineReplacementAsync(int scheduleDisciplineReplacementId) =>
            await _httpFacade.Get<ScheduleDisciplineReplacement>($"ScheduleDisciplineReplacements/{scheduleDisciplineReplacementId}");

        public async Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesAsync() =>
            await _httpFacade.Get<ScheduleDiscipline[]>($"ScheduleDisciplines/array");

        public async Task<ScheduleDisciplineReplacement[]> GetAllScheduleDisciplineReplacementsAsync() =>
            await _httpFacade.Get<ScheduleDisciplineReplacement[]>($"ScheduleDisciplineReplacements/array");

        public async Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesForWeekByDateWithIncludeAsync(DateTime date) =>
            await _httpFacade.Get<ScheduleDiscipline[]>($"ScheduleDisciplines/for-all/{date:yyyy-MM-dd}");

        public async Task<ScheduleDiscipline[]> GetCurrentScheduleDisciplinesForGroupWithIncludeAsync(int groupId) =>
            await _httpFacade.Get<ScheduleDiscipline[]>($"ScheduleDisciplines/for/{groupId}");

        public async Task<ScheduleDiscipline[]> GetAllScheduleDisciplinesForWeekByDateAndDepartmentWithIncludeAsync(int departmentId, DateTime date) =>
            await _httpFacade.Get<ScheduleDiscipline[]>($"ScheduleDisciplines/for-department/{departmentId}/{date}");

        public async Task<ScheduleDiscipline[]> GetCurrentScheduleDisciplinesForTeacherWithIncludeAsync(int teacherId) =>
            await _httpFacade.Get<ScheduleDiscipline[]>($"ScheduleDisciplines/for-teacher/{teacherId}");


        public async Task<ScheduleDiscipline> CreateScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline) =>
            await _httpFacade.Post<ScheduleDiscipline>($"ScheduleDisciplines", scheduleDiscipline);

        public async Task<ScheduleDisciplineReplacement> CreateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement) =>
            await _httpFacade.Post<ScheduleDisciplineReplacement>($"ScheduleDisciplineReplacements", scheduleDisciplineReplacement);

        public async Task<ScheduleDiscipline[]> CreateScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines) =>
            await _httpFacade.Post<ScheduleDiscipline[]>($"ScheduleDisciplines", scheduleDisciplines);

        public async Task<ScheduleDisciplineReplacement[]> CreateScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements) =>
            await _httpFacade.Post<ScheduleDisciplineReplacement[]>($"ScheduleDisciplineReplacements", scheduleDisciplineReplacements);


        public async Task<ScheduleDiscipline> UpdateScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline) =>
            await _httpFacade.Put<ScheduleDiscipline>($"ScheduleDisciplines", scheduleDiscipline);

        public async Task<ScheduleDisciplineReplacement> UpdateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement) =>
            await _httpFacade.Put<ScheduleDisciplineReplacement>($"ScheduleDisciplineReplacements", scheduleDisciplineReplacement);

        public async Task<ScheduleDiscipline[]> UpdateScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines) =>
            await _httpFacade.Put<ScheduleDiscipline[]>($"ScheduleDisciplines", scheduleDisciplines);

        public async Task<ScheduleDisciplineReplacement[]> UpdateScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements) =>
            await _httpFacade.Put<ScheduleDisciplineReplacement[]>($"ScheduleDisciplineReplacements", scheduleDisciplineReplacements);


        public async Task DeleteScheduleDisciplineAsync(ScheduleDisciplineRequest scheduleDiscipline) =>
            await _httpFacade.Delete($"ScheduleDisciplines", scheduleDiscipline);

        public async Task DeleteScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacementRequest scheduleDisciplineReplacement) =>
            await _httpFacade.Delete($"ScheduleDisciplineReplacementRequests", scheduleDisciplineReplacement);

        public async Task DeleteScheduleDisciplineArrayAsync(ScheduleDisciplineRequest[] scheduleDisciplines) =>
            await _httpFacade.Delete($"ScheduleDisciplines", scheduleDisciplines);

        public async Task DeleteScheduleDisciplineReplacementArrayAsync(ScheduleDisciplineReplacementRequest[] scheduleDisciplineReplacements) =>
            await _httpFacade.Delete($"ScheduleDisciplineReplacementRequests", scheduleDisciplineReplacements);
    }
}