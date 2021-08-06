using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IFederalStateEducationalStandardsClient
    {
        Task<FederalStateEducationalStandard> GetFederalStateEducationalStandardAsync(int federalStateEducationalStandardId);
        Task<FederalStateEducationalStandard[]> GetAllFederalStateEducationalStandardsAsync();
    }
}