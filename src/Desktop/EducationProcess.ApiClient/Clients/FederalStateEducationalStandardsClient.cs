using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class FederalStateEducationalStandardsClient : IFederalStateEducationalStandardsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal FederalStateEducationalStandardsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<FederalStateEducationalStandard> GetFederalStateEducationalStandardAsync(int employeeId) =>
            await _httpFacade.Get<FederalStateEducationalStandard>($"FederalStateEducationalStandards/{employeeId}");

        public async Task<FederalStateEducationalStandard[]> GetAllFederalStateEducationalStandardsAsync() =>
            await _httpFacade.Get<FederalStateEducationalStandard[]>($"FederalStateEducationalStandards/array");
    }
}