using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FederalStateEducationalStandardService : IFederalStateEducationalStandardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FederalStateEducationalStandardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FederalStateEducationalStandard> GetFederalStateEducationalStandardByIdAsync(int fsesId)
        {
            DataAccess.Entities.FederalStateEducationalStandard federalStateEducationalStandard =
                await _unitOfWork.FederalStateEducationalStandards.GetFirstWhereAsync(x => x.FsesId == fsesId);
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard, FederalStateEducationalStandard>(federalStateEducationalStandard);
        }

        public async Task<FederalStateEducationalStandard[]> GetAllFederalStateEducationalStandardsAsync()
        {
            DataAccess.Entities.FederalStateEducationalStandard[] federalStateEducationalStandard =
                await _unitOfWork.FederalStateEducationalStandards.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard[], FederalStateEducationalStandard[]>(federalStateEducationalStandard);
        }

        public async Task<FederalStateEducationalStandard> AddFederalStateEducationalStandardAsync(FederalStateEducationalStandard newFederalStateEducationalStandard)
        {
            DataAccess.Entities.FederalStateEducationalStandard federalStateEducationalStandard =
                _mapper.Map<FederalStateEducationalStandard, DataAccess.Entities.FederalStateEducationalStandard>(newFederalStateEducationalStandard);

            federalStateEducationalStandard = await _unitOfWork.FederalStateEducationalStandards.AddAsync(federalStateEducationalStandard);
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard, FederalStateEducationalStandard>(federalStateEducationalStandard);
        }

        public async Task<FederalStateEducationalStandard[]> AddRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] newFederalStateEducationalStandards)
        {
            DataAccess.Entities.FederalStateEducationalStandard[] federalStateEducationalStandards =
                _mapper.Map<FederalStateEducationalStandard[], DataAccess.Entities.FederalStateEducationalStandard[]>(newFederalStateEducationalStandards);

            federalStateEducationalStandards = await _unitOfWork.FederalStateEducationalStandards.AddRangeAsync(federalStateEducationalStandards);
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard[], FederalStateEducationalStandard[]>(federalStateEducationalStandards);
        }

        public async Task<FederalStateEducationalStandard> UpdateFederalStateEducationalStandardAsync(FederalStateEducationalStandard newFederalStateEducationalStandard)
        {
            DataAccess.Entities.FederalStateEducationalStandard federalStateEducationalStandard =
                _mapper.Map<FederalStateEducationalStandard, DataAccess.Entities.FederalStateEducationalStandard>(newFederalStateEducationalStandard);

            federalStateEducationalStandard = await _unitOfWork.FederalStateEducationalStandards.UpdateAsync(federalStateEducationalStandard);
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard, FederalStateEducationalStandard>(federalStateEducationalStandard);
        }

        public async Task<FederalStateEducationalStandard[]> UpdateRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] newFederalStateEducationalStandard)
        {
            DataAccess.Entities.FederalStateEducationalStandard[] federalStateEducationalStandard =
                _mapper.Map<FederalStateEducationalStandard[], DataAccess.Entities.FederalStateEducationalStandard[]>(newFederalStateEducationalStandard);

            federalStateEducationalStandard = await _unitOfWork.FederalStateEducationalStandards.UpdateRangeAsync(federalStateEducationalStandard);
            return _mapper.Map<DataAccess.Entities.FederalStateEducationalStandard[], FederalStateEducationalStandard[]>(federalStateEducationalStandard);
        }

        public async Task DeleteFederalStateEducationalStandardAsync(FederalStateEducationalStandard federalStateEducationalStandard)
        {
            DataAccess.Entities.FederalStateEducationalStandard mappedFederalStateEducationalStandard =
                _mapper.Map<FederalStateEducationalStandard, DataAccess.Entities.FederalStateEducationalStandard>(federalStateEducationalStandard);

            await _unitOfWork.FederalStateEducationalStandards.DeleteAsync(mappedFederalStateEducationalStandard);
        }

        public async Task DeleteRangeFederalStateEducationalStandardAsync(FederalStateEducationalStandard[] federalStateEducationalStandards)
        {
            DataAccess.Entities.FederalStateEducationalStandard[] mappedFederalStateEducationalStandards =
                _mapper.Map<FederalStateEducationalStandard[], DataAccess.Entities.FederalStateEducationalStandard[]>(federalStateEducationalStandards);

            await _unitOfWork.FederalStateEducationalStandards.DeleteRangeAsync(mappedFederalStateEducationalStandards);
        }
    }
}