using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.EducationPlans.Requests;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class EducationPlansClient : IEducationPlansClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal EducationPlansClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<EducationPlan> GetEducationPlanAsync(int educationPlanId) =>
            await _httpFacade.Get<EducationPlan>($"EducationPlans/{educationPlanId}");

        public async Task<EducationPlan[]> GetAllEducationPlansAsync() =>
            await _httpFacade.Get<EducationPlan[]>($"EducationPlans/array");


        public async Task<EducationPlan> CreateEducationPlanAsync(EducationPlanRequest educationPlan) =>
            await _httpFacade.Post<EducationPlan>($"EducationPlans", educationPlan);

        public async Task<EducationPlan[]> CreateEducationPlanArrayAsync(EducationPlanRequest[] educationPlans) =>
            await _httpFacade.Post<EducationPlan[]>($"EducationPlans", educationPlans);

        public async Task<EducationPlanWithSemesterDisciplinesResponse> CreateEducationPlanWithSemesterDisciplinesAsync(CreateEducationPlanWithSemesterDisciplinesRequest educationPlan) =>
            await _httpFacade.Post<EducationPlanWithSemesterDisciplinesResponse>($"EducationPlans", educationPlan);


        public async Task<EducationPlan> UpdateEducationPlanAsync(EducationPlanRequest educationPlan) =>
            await _httpFacade.Put<EducationPlan>($"EducationPlans", educationPlan);

        public async Task<EducationPlan[]> UpdateEducationPlanArrayAsync(EducationPlanRequest[] educationPlans) =>
            await _httpFacade.Put<EducationPlan[]>($"EducationPlans", educationPlans);


        public async Task DeleteEducationPlanAsync(EducationPlanRequest educationPlan) =>
            await _httpFacade.Delete($"EducationPlans", educationPlan);

        public async Task DeleteEducationPlanArrayAsync(EducationPlanRequest[] educationPlans) =>
            await _httpFacade.Delete($"EducationPlans", educationPlans);
    }
}