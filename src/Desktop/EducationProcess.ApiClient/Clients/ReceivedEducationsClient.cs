using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.ReceivedEducations.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class ReceivedEducationsClient : IReceivedEducationsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal ReceivedEducationsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<ReceivedEducation> GetReceivedEducationAsync(int receivedEducationId) =>
            await _httpFacade.Get<ReceivedEducation>($"ReceivedEducations/{receivedEducationId}");

        public async Task<ReceivedEducation[]> GetAllReceivedEducationsAsync() =>
            await _httpFacade.Get<ReceivedEducation[]>($"ReceivedEducations/array");
    }
}