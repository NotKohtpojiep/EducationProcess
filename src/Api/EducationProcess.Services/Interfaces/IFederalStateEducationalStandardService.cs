using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IFederalStateEducationalStandardService
    {
        Task<FederalStateEducationalStandard> GetFederalStateEducationalStandardByIdAsync(int fsesId);
        Task<FederalStateEducationalStandard[]> GetAllFederalStateEducationalStandardsAsync();
        Task<FederalStateEducationalStandard> AddFederalStateEducationalStandardAsync(FederalStateEducationalStandard newFederalStateEducationalStandard);
        Task<FederalStateEducationalStandard[]> AddRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] newFederalStateEducationalStandards);
        Task<FederalStateEducationalStandard> UpdateFederalStateEducationalStandardAsync(FederalStateEducationalStandard newFederalStateEducationalStandard);
        Task<FederalStateEducationalStandard[]> UpdateRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] newFederalStateEducationalStandard);
        Task DeleteFederalStateEducationalStandardAsync(FederalStateEducationalStandard federalStateEducationalStandard);
        Task DeleteRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] federalStateEducationalStandards);
    }
}