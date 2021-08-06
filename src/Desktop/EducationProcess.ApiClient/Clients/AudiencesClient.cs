using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Audiences.Requests;
using EducationProcess.ApiClient.Models.Audiences.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class AudiencesClient : IAudiencesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal AudiencesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Audience> GetAudienceAsync(int audienceId) =>
            await _httpFacade.Get<Audience>($"Audiences/{audienceId}");

        public async Task<Audience[]> GetAllAudiencesAsync() =>
            await _httpFacade.Get<Audience[]>($"Audiences/array");


        public async Task<Audience> CreateAudienceAsync(AudienceRequest audience) =>
            await _httpFacade.Post<Audience>($"Audiences", audience);

        public async Task<Audience[]> CreateAudienceArrayAsync(AudienceRequest[] audiences) =>
            await _httpFacade.Post<Audience[]>($"Audiences", audiences);


        public async Task<Audience> UpdateAudienceAsync(AudienceRequest audience) =>
            await _httpFacade.Put<Audience>($"Audiences", audience);

        public async Task<Audience[]> UpdateAudienceArrayAsync(AudienceRequest[] audiences) =>
            await _httpFacade.Put<Audience[]>($"Audiences", audiences);


        public async Task DeleteAudienceAsync(AudienceRequest audience) =>
            await _httpFacade.Delete($"Audiences", audience);

        public async Task DeleteAudienceArrayAsync(AudienceRequest[] audiences) =>
            await _httpFacade.Delete($"Audiences", audiences);
    }
}