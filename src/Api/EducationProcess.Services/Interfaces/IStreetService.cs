using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IStreetService
    {
        Task<Street> GetStreetByIdAsync(int streetId);
        Task<Street[]> GetAllStreetsAsync();
        Task<Street> AddStreetAsync(Street newStreet);
        Task<Street[]> AddRangeStreetAsync(Street[] newStreets);
        Task<Street> UpdateStreetAsync(Street newStreet);
        Task<Street[]> UpdateRangeStreetAsync(Street[] newStreet);
        Task DeleteStreetAsync(Street street);
        Task DeleteRangeStreetAsync(Street[] streets);
    }
}
