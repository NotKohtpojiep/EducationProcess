using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Audiences.Requests;
using EducationProcess.ApiClient.Models.Audiences.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IAudiencesClient
    {
        Task<Audience> GetAudienceAsync(int audienceId);
        Task<Audience[]> GetAllAudiencesAsync();

        Task<Audience> CreateAudienceAsync(AudienceRequest audience);
        Task<Audience[]> CreateAudienceArrayAsync(AudienceRequest[] audiences);

        Task<Audience> UpdateAudienceAsync(AudienceRequest audience);
        Task<Audience[]> UpdateAudienceArrayAsync(AudienceRequest[] audiences);

        Task DeleteAudienceAsync(AudienceRequest audience);
        Task DeleteAudienceArrayAsync(AudienceRequest[] audiences);
    }
}