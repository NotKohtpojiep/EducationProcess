using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationLevel> GetEducationLevelByIdAsync(int educationLevelId)
        {
            DataAccess.Entities.EducationLevel educationLevel =
                await _unitOfWork.EducationLevels.GetFirstWhereAsync(x => x.EducationLevelId == educationLevelId);
            return _mapper.Map<DataAccess.Entities.EducationLevel, EducationLevel>(educationLevel);
        }

        public async Task<EducationLevel[]> GetAllEducationLevelsAsync()
        {
            DataAccess.Entities.EducationLevel[] educationLevel =
                await _unitOfWork.EducationLevels.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EducationLevel[], EducationLevel[]>(educationLevel);
        }

        public async Task<EducationLevel> AddEducationLevelAsync(EducationLevel newEducationLevel)
        {
            DataAccess.Entities.EducationLevel educationLevel =
                _mapper.Map<EducationLevel, DataAccess.Entities.EducationLevel>(newEducationLevel);

            educationLevel = await _unitOfWork.EducationLevels.AddAsync(educationLevel);
            return _mapper.Map<DataAccess.Entities.EducationLevel, EducationLevel>(educationLevel);
        }

        public async Task<EducationLevel[]> AddRangeEducationLevelAsync(EducationLevel[] newEducationLevels)
        {
            DataAccess.Entities.EducationLevel[] educationLevels =
                _mapper.Map<EducationLevel[], DataAccess.Entities.EducationLevel[]>(newEducationLevels);

            educationLevels = await _unitOfWork.EducationLevels.AddRangeAsync(educationLevels);
            return _mapper.Map<DataAccess.Entities.EducationLevel[], EducationLevel[]>(educationLevels);
        }

        public async Task<EducationLevel> UpdateEducationLevelAsync(EducationLevel newEducationLevel)
        {
            DataAccess.Entities.EducationLevel educationLevel =
                _mapper.Map<EducationLevel, DataAccess.Entities.EducationLevel>(newEducationLevel);

            educationLevel = await _unitOfWork.EducationLevels.UpdateAsync(educationLevel);
            return _mapper.Map<DataAccess.Entities.EducationLevel, EducationLevel>(educationLevel);
        }

        public async Task<EducationLevel[]> UpdateRangeEducationLevelAsync(EducationLevel[] newEducationLevel)
        {
            DataAccess.Entities.EducationLevel[] educationLevel =
                _mapper.Map<EducationLevel[], DataAccess.Entities.EducationLevel[]>(newEducationLevel);

            educationLevel = await _unitOfWork.EducationLevels.UpdateRangeAsync(educationLevel);
            return _mapper.Map<DataAccess.Entities.EducationLevel[], EducationLevel[]>(educationLevel);
        }

        public async Task DeleteEducationLevelAsync(EducationLevel educationLevel)
        {
            DataAccess.Entities.EducationLevel mappedEducationLevel =
                _mapper.Map<EducationLevel, DataAccess.Entities.EducationLevel>(educationLevel);

            await _unitOfWork.EducationLevels.DeleteAsync(mappedEducationLevel);
        }

        public async Task DeleteRangeEducationLevelAsync(EducationLevel[] educationLevels)
        {
            DataAccess.Entities.EducationLevel[] mappedEducationLevels =
                _mapper.Map<EducationLevel[], DataAccess.Entities.EducationLevel[]>(educationLevels);

            await _unitOfWork.EducationLevels.DeleteRangeAsync(mappedEducationLevels);
        }
    }
}