using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEducationPlanService
    {
        Task<EducationPlan> GetEducationPlanByIdAsync(int educationPlanId);
        Task<EducationPlan[]> GetAllEducationPlansAsync();
        Task<EducationPlan> AddEducationPlanAsync(EducationPlan newEducationPlan);
        Task<EducationPlan[]> AddRangeEducationPlanAsync(EducationPlan[] newEducationPlans);
        Task<EducationPlan> UpdateEducationPlanAsync(EducationPlan newEducationPlan);
        Task<EducationPlan[]> UpdateRangeEducationPlanAsync(EducationPlan[] newEducationPlan);
        Task DeleteEducationPlanAsync(EducationPlan educationPlan);
        Task DeleteRangeEducationPlanAsync(EducationPlan[] educationPlans);
    }
}