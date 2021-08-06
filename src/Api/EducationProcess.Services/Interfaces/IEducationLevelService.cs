using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEducationLevelService
    {
        Task<EducationLevel> GetEducationLevelByIdAsync(int educationLevelId);
        Task<EducationLevel[]> GetAllEducationLevelsAsync();
        Task<EducationLevel> AddEducationLevelAsync(EducationLevel newEducationLevel);
        Task<EducationLevel[]> AddRangeEducationLevelAsync(EducationLevel[] newEducationLevels);
        Task<EducationLevel> UpdateEducationLevelAsync(EducationLevel newEducationLevel);
        Task<EducationLevel[]> UpdateRangeEducationLevelAsync(EducationLevel[] newEducationLevel);
        Task DeleteEducationLevelAsync(EducationLevel educationLevel);
        Task DeleteRangeEducationLevelAsync(EducationLevel[] educationLevels);
    }
}