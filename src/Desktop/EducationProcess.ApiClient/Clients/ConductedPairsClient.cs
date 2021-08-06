using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.ConductedPairs.Requests;
using EducationProcess.ApiClient.Models.ConductedPairs.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class ConductedPairsClient : IConductedPairsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal ConductedPairsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<ConductedPair> GetConductedPairAsync(int conductedPairId) =>
            await _httpFacade.Get<ConductedPair>($"ConductedPairs/{conductedPairId}");

        public async Task<ConductedPair[]> GetAllConductedPairsAsync() =>
            await _httpFacade.Get<ConductedPair[]>($"ConductedPairs/array");


        public async Task<ConductedPair> CreateConductedPairAsync(ConductedPairRequest conductedPair) =>
            await _httpFacade.Post<ConductedPair>($"ConductedPairs", conductedPair);

        public async Task<ConductedPair[]> CreateConductedPairArrayAsync(ConductedPairRequest[] conductedPairs) =>
            await _httpFacade.Post<ConductedPair[]>($"ConductedPairs", conductedPairs);


        public async Task<ConductedPair> UpdateConductedPairAsync(ConductedPairRequest conductedPair) =>
            await _httpFacade.Put<ConductedPair>($"ConductedPairs", conductedPair);

        public async Task<ConductedPair[]> UpdateConductedPairArrayAsync(ConductedPairRequest[] conductedPairs) =>
            await _httpFacade.Put<ConductedPair[]>($"ConductedPairs", conductedPairs);


        public async Task DeleteConductedPairAsync(ConductedPairRequest conductedPair) =>
            await _httpFacade.Delete($"ConductedPairs", conductedPair);

        public async Task DeleteConductedPairArrayAsync(ConductedPairRequest[] conductedPairs) =>
            await _httpFacade.Delete($"ConductedPairs", conductedPairs);
    }
}