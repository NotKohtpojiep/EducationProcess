using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IScheduleDisciplineReplacementService
    {
        Task<ScheduleDisciplineReplacement> GetScheduleDisciplineReplacementByIdAsync(int scheduleDisciplineReplacementId);
        Task<ScheduleDisciplineReplacement[]> GetAllScheduleDisciplineReplacementsAsync();
        Task<ScheduleDisciplineReplacement> AddScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement newScheduleDisciplineReplacement);
        Task<ScheduleDisciplineReplacement[]> AddRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] newScheduleDisciplineReplacements);
        Task<ScheduleDisciplineReplacement> UpdateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement newScheduleDisciplineReplacement);
        Task<ScheduleDisciplineReplacement[]> UpdateRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] newScheduleDisciplineReplacement);
        Task DeleteScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement scheduleDisciplineReplacement);
        Task DeleteRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] scheduleDisciplineReplacements);
    }
}