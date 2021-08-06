using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.ConductedPairs.Requests;
using EducationProcess.ApiClient.Models.ConductedPairs.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IConductedPairsClient
    {
        Task<ConductedPair> GetConductedPairAsync(int conductedPairId);
        Task<ConductedPair[]> GetAllConductedPairsAsync();

        Task<ConductedPair> CreateConductedPairAsync(ConductedPairRequest conductedPair);
        Task<ConductedPair[]> CreateConductedPairArrayAsync(ConductedPairRequest[] conductedPairs);

        Task<ConductedPair> UpdateConductedPairAsync(ConductedPairRequest conductedPair);
        Task<ConductedPair[]> UpdateConductedPairArrayAsync(ConductedPairRequest[] conductedPairs);

        Task DeleteConductedPairAsync(ConductedPairRequest conductedPair);
        Task DeleteConductedPairArrayAsync(ConductedPairRequest[] conductedPairs);
    }
}