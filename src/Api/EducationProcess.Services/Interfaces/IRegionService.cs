using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IRegionService
    {
        Task<Region> GetRegionByIdAsync(int regionId);
        Task<Region[]> GetAllRegionsAsync();
        Task<Region> AddRegionAsync(Region newRegion);
        Task<Region[]> AddRangeRegionAsync(Region[] newRegions);
        Task<Region> UpdateRegionAsync(Region newRegion);
        Task<Region[]> UpdateRangeRegionAsync(Region[] newRegion);
        Task DeleteRegionAsync(Region region);
        Task DeleteRangeRegionAsync(Region[] regions);
    }
}
