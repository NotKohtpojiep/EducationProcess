using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FsesCategoryPartitionService : IFsesCategoryPartitionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FsesCategoryPartitionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FsesCategoryPartition> GetFsesCategoryPartitionByIdAsync(int fsesCategoryPartitionId)
        {
            DataAccess.Entities.FsesCategoryPartition fsesCategoryPartition =
                await _unitOfWork.FsesCategoryPartitions.GetFirstWhereAsync(x => x.FsesCategoryPartitionId == fsesCategoryPartitionId);
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition, FsesCategoryPartition>(fsesCategoryPartition);
        }

        public async Task<FsesCategoryPartition[]> GetAllFsesCategoryPartitionsAsync()
        {
            DataAccess.Entities.FsesCategoryPartition[] fsesCategoryPartition =
                await _unitOfWork.FsesCategoryPartitions.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition[], FsesCategoryPartition[]>(fsesCategoryPartition);
        }

        public async Task<FsesCategoryPartition> AddFsesCategoryPartitionAsync(FsesCategoryPartition newFsesCategoryPartition)
        {
            DataAccess.Entities.FsesCategoryPartition fsesCategoryPartition =
                _mapper.Map<FsesCategoryPartition, DataAccess.Entities.FsesCategoryPartition>(newFsesCategoryPartition);

            fsesCategoryPartition = await _unitOfWork.FsesCategoryPartitions.AddAsync(fsesCategoryPartition);
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition, FsesCategoryPartition>(fsesCategoryPartition);
        }

        public async Task<FsesCategoryPartition[]> AddRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] newFsesCategoryPartitions)
        {
            DataAccess.Entities.FsesCategoryPartition[] fsesCategoryPartitions =
                _mapper.Map<FsesCategoryPartition[], DataAccess.Entities.FsesCategoryPartition[]>(newFsesCategoryPartitions);

            fsesCategoryPartitions = await _unitOfWork.FsesCategoryPartitions.AddRangeAsync(fsesCategoryPartitions);
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition[], FsesCategoryPartition[]>(fsesCategoryPartitions);
        }

        public async Task<FsesCategoryPartition> UpdateFsesCategoryPartitionAsync(FsesCategoryPartition newFsesCategoryPartition)
        {
            DataAccess.Entities.FsesCategoryPartition fsesCategoryPartition =
                _mapper.Map<FsesCategoryPartition, DataAccess.Entities.FsesCategoryPartition>(newFsesCategoryPartition);

            fsesCategoryPartition = await _unitOfWork.FsesCategoryPartitions.UpdateAsync(fsesCategoryPartition);
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition, FsesCategoryPartition>(fsesCategoryPartition);
        }

        public async Task<FsesCategoryPartition[]> UpdateRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] newFsesCategoryPartition)
        {
            DataAccess.Entities.FsesCategoryPartition[] fsesCategoryPartition =
                _mapper.Map<FsesCategoryPartition[], DataAccess.Entities.FsesCategoryPartition[]>(newFsesCategoryPartition);

            fsesCategoryPartition = await _unitOfWork.FsesCategoryPartitions.UpdateRangeAsync(fsesCategoryPartition);
            return _mapper.Map<DataAccess.Entities.FsesCategoryPartition[], FsesCategoryPartition[]>(fsesCategoryPartition);
        }

        public async Task DeleteFsesCategoryPartitionAsync(FsesCategoryPartition fsesCategoryPartition)
        {
            DataAccess.Entities.FsesCategoryPartition mappedFsesCategoryPartition =
                _mapper.Map<FsesCategoryPartition, DataAccess.Entities.FsesCategoryPartition>(fsesCategoryPartition);

            await _unitOfWork.FsesCategoryPartitions.DeleteAsync(mappedFsesCategoryPartition);
        }

        public async Task DeleteRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] fsesCategoryPartitions)
        {
            DataAccess.Entities.FsesCategoryPartition[] mappedFsesCategoryPartitions =
                _mapper.Map<FsesCategoryPartition[], DataAccess.Entities.FsesCategoryPartition[]>(fsesCategoryPartitions);

            await _unitOfWork.FsesCategoryPartitions.DeleteRangeAsync(mappedFsesCategoryPartitions);
        }
    }
}