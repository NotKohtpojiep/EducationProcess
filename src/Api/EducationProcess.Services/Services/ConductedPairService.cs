using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ConductedPairService : IConductedPairService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConductedPairService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ConductedPair> GetConductedPairByIdAsync(int conductedPairId)
        {
            DataAccess.Entities.ConductedPair conductedPair =
                await _unitOfWork.ConductedPairs.GetFirstWhereAsync(x => x.ConductedPairId == conductedPairId);
            return _mapper.Map<DataAccess.Entities.ConductedPair, ConductedPair>(conductedPair);
        }

        public async Task<ConductedPair[]> GetAllConductedPairsAsync()
        {
            DataAccess.Entities.ConductedPair[] conductedPair =
                await _unitOfWork.ConductedPairs.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.ConductedPair[], ConductedPair[]>(conductedPair);
        }

        public async Task<ConductedPair> AddConductedPairAsync(ConductedPair newConductedPair)
        {
            DataAccess.Entities.ConductedPair conductedPair =
                _mapper.Map<ConductedPair, DataAccess.Entities.ConductedPair>(newConductedPair);

            conductedPair = await _unitOfWork.ConductedPairs.AddAsync(conductedPair);
            return _mapper.Map<DataAccess.Entities.ConductedPair, ConductedPair>(conductedPair);
        }

        public async Task<ConductedPair[]> AddRangeConductedPairAsync(ConductedPair[] newConductedPairs)
        {
            DataAccess.Entities.ConductedPair[] conductedPairs =
                _mapper.Map<ConductedPair[], DataAccess.Entities.ConductedPair[]>(newConductedPairs);

            conductedPairs = await _unitOfWork.ConductedPairs.AddRangeAsync(conductedPairs);
            return _mapper.Map<DataAccess.Entities.ConductedPair[], ConductedPair[]>(conductedPairs);
        }

        public async Task<ConductedPair> UpdateConductedPairAsync(ConductedPair newConductedPair)
        {
            DataAccess.Entities.ConductedPair conductedPair =
                _mapper.Map<ConductedPair, DataAccess.Entities.ConductedPair>(newConductedPair);

            conductedPair = await _unitOfWork.ConductedPairs.UpdateAsync(conductedPair);
            return _mapper.Map<DataAccess.Entities.ConductedPair, ConductedPair>(conductedPair);
        }

        public async Task<ConductedPair[]> UpdateRangeConductedPairAsync(ConductedPair[] newConductedPair)
        {
            DataAccess.Entities.ConductedPair[] conductedPair =
                _mapper.Map<ConductedPair[], DataAccess.Entities.ConductedPair[]>(newConductedPair);

            conductedPair = await _unitOfWork.ConductedPairs.UpdateRangeAsync(conductedPair);
            return _mapper.Map<DataAccess.Entities.ConductedPair[], ConductedPair[]>(conductedPair);
        }

        public async Task DeleteConductedPairAsync(ConductedPair conductedPair)
        {
            DataAccess.Entities.ConductedPair mappedConductedPair =
                _mapper.Map<ConductedPair, DataAccess.Entities.ConductedPair>(conductedPair);

            await _unitOfWork.ConductedPairs.DeleteAsync(mappedConductedPair);
        }

        public async Task DeleteRangeConductedPairAsync(ConductedPair[] conductedPairs)
        {
            DataAccess.Entities.ConductedPair[] mappedConductedPairs =
                _mapper.Map<ConductedPair[], DataAccess.Entities.ConductedPair[]>(conductedPairs);

            await _unitOfWork.ConductedPairs.DeleteRangeAsync(mappedConductedPairs);
        }
    }
}