using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.EducationPlans.Requests;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IEducationPlansClient
    {
        Task<EducationPlan> GetEducationPlanAsync(int educationPlanId);
        Task<EducationPlan[]> GetAllEducationPlansAsync();

        Task<EducationPlan> CreateEducationPlanAsync(EducationPlanRequest educationPlan);
        Task<EducationPlan[]> CreateEducationPlanArrayAsync(EducationPlanRequest[] educationPlans);
        Task<EducationPlanWithSemesterDisciplinesResponse> CreateEducationPlanWithSemesterDisciplinesAsync(CreateEducationPlanWithSemesterDisciplinesRequest educationPlan);

        Task<EducationPlan> UpdateEducationPlanAsync(EducationPlanRequest educationPlan);
        Task<EducationPlan[]> UpdateEducationPlanArrayAsync(EducationPlanRequest[] educationPlans);

        Task DeleteEducationPlanAsync(EducationPlanRequest educationPlan);
        Task DeleteEducationPlanArrayAsync(EducationPlanRequest[] educationPlans);
    }
}