using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEducationCyclesAndModuleService
    {
        Task<EducationCyclesAndModule> GetEducationCyclesAndModuleByIdAsync(int educationCycleId);
        Task<EducationCyclesAndModule[]> GetAllEducationCyclesAndModulesAsync();
        Task<EducationCyclesAndModule> AddEducationCyclesAndModuleAsync(EducationCyclesAndModule newEducationCyclesAndModule);
        Task<EducationCyclesAndModule[]> AddRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] newEducationCyclesAndModules);
        Task<EducationCyclesAndModule> UpdateEducationCyclesAndModuleAsync(EducationCyclesAndModule newEducationCyclesAndModule);
        Task<EducationCyclesAndModule[]> UpdateRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] newEducationCyclesAndModule);
        Task DeleteEducationCyclesAndModuleAsync(EducationCyclesAndModule educationCyclesAndModule);
        Task DeleteRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] educationCyclesAndModules);
    }
}