using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationCyclesAndModuleService : IEducationCyclesAndModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationCyclesAndModuleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationCyclesAndModule> GetEducationCyclesAndModuleByIdAsync(int educationCycleId)
        {
            DataAccess.Entities.EducationCyclesAndModule educationCyclesAndModule =
                await _unitOfWork.EducationCyclesAndModules.GetFirstWhereAsync(x => x.EducationCycleId == educationCycleId);
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule, EducationCyclesAndModule>(educationCyclesAndModule);
        }

        public async Task<EducationCyclesAndModule[]> GetAllEducationCyclesAndModulesAsync()
        {
            DataAccess.Entities.EducationCyclesAndModule[] educationCyclesAndModule =
                await _unitOfWork.EducationCyclesAndModules.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule[], EducationCyclesAndModule[]>(educationCyclesAndModule);
        }

        public async Task<EducationCyclesAndModule> AddEducationCyclesAndModuleAsync(EducationCyclesAndModule newEducationCyclesAndModule)
        {
            DataAccess.Entities.EducationCyclesAndModule educationCyclesAndModule =
                _mapper.Map<EducationCyclesAndModule, DataAccess.Entities.EducationCyclesAndModule>(newEducationCyclesAndModule);

            educationCyclesAndModule = await _unitOfWork.EducationCyclesAndModules.AddAsync(educationCyclesAndModule);
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule, EducationCyclesAndModule>(educationCyclesAndModule);
        }

        public async Task<EducationCyclesAndModule[]> AddRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] newEducationCyclesAndModules)
        {
            DataAccess.Entities.EducationCyclesAndModule[] educationCyclesAndModules =
                _mapper.Map<EducationCyclesAndModule[], DataAccess.Entities.EducationCyclesAndModule[]>(newEducationCyclesAndModules);

            educationCyclesAndModules = await _unitOfWork.EducationCyclesAndModules.AddRangeAsync(educationCyclesAndModules);
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule[], EducationCyclesAndModule[]>(educationCyclesAndModules);
        }

        public async Task<EducationCyclesAndModule> UpdateEducationCyclesAndModuleAsync(EducationCyclesAndModule newEducationCyclesAndModule)
        {
            DataAccess.Entities.EducationCyclesAndModule educationCyclesAndModule =
                _mapper.Map<EducationCyclesAndModule, DataAccess.Entities.EducationCyclesAndModule>(newEducationCyclesAndModule);

            educationCyclesAndModule = await _unitOfWork.EducationCyclesAndModules.UpdateAsync(educationCyclesAndModule);
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule, EducationCyclesAndModule>(educationCyclesAndModule);
        }

        public async Task<EducationCyclesAndModule[]> UpdateRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] newEducationCyclesAndModule)
        {
            DataAccess.Entities.EducationCyclesAndModule[] educationCyclesAndModule =
                _mapper.Map<EducationCyclesAndModule[], DataAccess.Entities.EducationCyclesAndModule[]>(newEducationCyclesAndModule);

            educationCyclesAndModule = await _unitOfWork.EducationCyclesAndModules.UpdateRangeAsync(educationCyclesAndModule);
            return _mapper.Map<DataAccess.Entities.EducationCyclesAndModule[], EducationCyclesAndModule[]>(educationCyclesAndModule);
        }

        public async Task DeleteEducationCyclesAndModuleAsync(EducationCyclesAndModule educationCyclesAndModule)
        {
            DataAccess.Entities.EducationCyclesAndModule mappedEducationCyclesAndModule =
                _mapper.Map<EducationCyclesAndModule, DataAccess.Entities.EducationCyclesAndModule>(educationCyclesAndModule);

            await _unitOfWork.EducationCyclesAndModules.DeleteAsync(mappedEducationCyclesAndModule);
        }

        public async Task DeleteRangeEducationCyclesAndModuleAsync(EducationCyclesAndModule[] educationCyclesAndModules)
        {
            DataAccess.Entities.EducationCyclesAndModule[] mappedEducationCyclesAndModules =
                _mapper.Map<EducationCyclesAndModule[], DataAccess.Entities.EducationCyclesAndModule[]>(educationCyclesAndModules);

            await _unitOfWork.EducationCyclesAndModules.DeleteRangeAsync(mappedEducationCyclesAndModules);
        }
    }
}