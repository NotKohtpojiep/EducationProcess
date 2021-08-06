using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Region> GetRegionByIdAsync(int regionId)
        {
            DataAccess.Entities.Region region =
                await _unitOfWork.Regions.GetFirstWhereAsync(x => x.RegionId == regionId);
            return _mapper.Map<DataAccess.Entities.Region, Region>(region);
        }

        public async Task<Region[]> GetAllRegionsAsync()
        {
            DataAccess.Entities.Region[] region =
                await _unitOfWork.Regions.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Region[], Region[]>(region);
        }

        public async Task<Region> AddRegionAsync(Region newRegion)
        {
            DataAccess.Entities.Region region =
                _mapper.Map<Region, DataAccess.Entities.Region>(newRegion);

            region = await _unitOfWork.Regions.AddAsync(region);
            return _mapper.Map<DataAccess.Entities.Region, Region>(region);
        }

        public async Task<Region[]> AddRangeRegionAsync(Region[] newRegions)
        {
            DataAccess.Entities.Region[] regions =
                _mapper.Map<Region[], DataAccess.Entities.Region[]>(newRegions);

            regions = await _unitOfWork.Regions.AddRangeAsync(regions);
            return _mapper.Map<DataAccess.Entities.Region[], Region[]>(regions);
        }

        public async Task<Region> UpdateRegionAsync(Region newRegion)
        {
            DataAccess.Entities.Region region =
                _mapper.Map<Region, DataAccess.Entities.Region>(newRegion);

            region = await _unitOfWork.Regions.UpdateAsync(region);
            return _mapper.Map<DataAccess.Entities.Region, Region>(region);
        }

        public async Task<Region[]> UpdateRangeRegionAsync(Region[] newRegion)
        {
            DataAccess.Entities.Region[] region =
                _mapper.Map<Region[], DataAccess.Entities.Region[]>(newRegion);

            region = await _unitOfWork.Regions.UpdateRangeAsync(region);
            return _mapper.Map<DataAccess.Entities.Region[], Region[]>(region);
        }

        public async Task DeleteRegionAsync(Region region)
        {
            DataAccess.Entities.Region mappedRegion =
                _mapper.Map<Region, DataAccess.Entities.Region>(region);

            await _unitOfWork.Regions.DeleteAsync(mappedRegion);
        }

        public async Task DeleteRangeRegionAsync(Region[] regions)
        {
            DataAccess.Entities.Region[] mappedRegions =
                _mapper.Map<Region[], DataAccess.Entities.Region[]>(regions);

            await _unitOfWork.Regions.DeleteRangeAsync(mappedRegions);
        }
    }
}