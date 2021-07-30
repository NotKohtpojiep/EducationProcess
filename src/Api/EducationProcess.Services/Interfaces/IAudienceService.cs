using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IAudienceService
    {
        Task<Audience> GetAudienceByIdAsync(int audienceId);
        Task<Audience[]> GetAllAudiencesAsync();
        Task<Audience> AddAudienceAsync(Audience newAudience);
        Task<Audience[]> AddRangeAudienceAsync(Audience[] newAudiences);
        Task<Audience> UpdateAudienceAsync(Audience newAudience);
        Task<Audience[]> UpdateRangeAudienceAsync(Audience[] newAudience);
        Task DeleteAudienceAsync(Audience audience);
        Task DeleteRangeAudienceAsync(Audience[] audiences);
    }
}
