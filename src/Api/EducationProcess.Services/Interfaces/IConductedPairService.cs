using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IConductedPairService
    {
        Task<ConductedPair> GetConductedPairByIdAsync(int conductedPairId);
        Task<ConductedPair[]> GetAllConductedPairsAsync();
        Task<ConductedPair> AddConductedPairAsync(ConductedPair newConductedPair);
        Task<ConductedPair[]> AddRangeConductedPairAsync(ConductedPair[] newConductedPairs);
        Task<ConductedPair> UpdateConductedPairAsync(ConductedPair newConductedPair);
        Task<ConductedPair[]> UpdateRangeConductedPairAsync(ConductedPair[] newConductedPair);
        Task DeleteConductedPairAsync(ConductedPair conductedPair);
        Task DeleteRangeConductedPairAsync(ConductedPair[] conductedPairs);
    }
}