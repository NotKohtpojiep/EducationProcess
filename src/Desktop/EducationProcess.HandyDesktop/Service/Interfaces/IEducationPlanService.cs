using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.HandyDesktop.Service
{
    public interface IEducationPlanService
    {
        Task<EducationPlan[]> GetAllEducationPlans();
        Task<EducationPlan> CreateEducationPlan(EducationPlan educationPlan);
    }
}
