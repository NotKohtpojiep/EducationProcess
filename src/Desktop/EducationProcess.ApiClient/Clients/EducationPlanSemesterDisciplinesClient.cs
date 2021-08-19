using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class EducationPlanSemesterDisciplinesClient : IEducationPlanSemesterDisciplinesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal EducationPlanSemesterDisciplinesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdAsync(int educationPlanId) =>
            await _httpFacade.Get<EducationPlanSemesterDiscipline[]>($"EducationPlanSemesterDisciplines​/range​/by-education-plan​/{educationPlanId}");

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithIncludeAsync(int educationPlanId) =>
            await _httpFacade.Get<EducationPlanSemesterDiscipline[]>($"EducationPlanSemesterDisciplines/range/by-education-plan/with-include/{educationPlanId}");

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesBySemesterDisciplineIdAsync(int semesterDisciplineId) =>
            await _httpFacade.Get<EducationPlanSemesterDiscipline[]>($"EducationPlanSemesterDisciplines​/range​/by-semester-discipline​/{semesterDisciplineId}");

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesAsync() =>
            await _httpFacade.Get<EducationPlanSemesterDiscipline[]>($"EducationPlanSemesterDisciplines/array");
    }
}