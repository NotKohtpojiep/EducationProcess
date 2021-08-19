using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IEducationPlanService
    {
        Task<EducationPlan[]> GetAllEducationPlans();
        Task<EducationPlan> CreateEducationPlan(EducationPlan educationPlan);
    }
}
