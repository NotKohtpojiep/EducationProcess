using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationPlanService : IEducationPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationPlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationPlan> GetEducationPlanByIdAsync(int educationPlanId)
        {
            DataAccess.Entities.EducationPlan educationPlan =
                await _unitOfWork.EducationPlans.GetFirstWhereAsync(x => x.EducationPlanId == educationPlanId);
            return _mapper.Map<DataAccess.Entities.EducationPlan, EducationPlan>(educationPlan);
        }

        public async Task<EducationPlan[]> GetAllEducationPlansAsync()
        {
            DataAccess.Entities.EducationPlan[] educationPlan =
                await _unitOfWork.EducationPlans.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EducationPlan[], EducationPlan[]>(educationPlan);
        }

        public async Task<EducationPlan> AddEducationPlanAsync(EducationPlan newEducationPlan)
        {
            DataAccess.Entities.EducationPlan educationPlan =
                _mapper.Map<EducationPlan, DataAccess.Entities.EducationPlan>(newEducationPlan);

            educationPlan = await _unitOfWork.EducationPlans.AddAsync(educationPlan);
            return _mapper.Map<DataAccess.Entities.EducationPlan, EducationPlan>(educationPlan);
        }

        public async Task<EducationPlan[]> AddRangeEducationPlanAsync(EducationPlan[] newEducationPlans)
        {
            DataAccess.Entities.EducationPlan[] educationPlans =
                _mapper.Map<EducationPlan[], DataAccess.Entities.EducationPlan[]>(newEducationPlans);

            educationPlans = await _unitOfWork.EducationPlans.AddRangeAsync(educationPlans);
            return _mapper.Map<DataAccess.Entities.EducationPlan[], EducationPlan[]>(educationPlans);
        }

        public async Task<EducationPlan> UpdateEducationPlanAsync(EducationPlan newEducationPlan)
        {
            DataAccess.Entities.EducationPlan educationPlan =
                _mapper.Map<EducationPlan, DataAccess.Entities.EducationPlan>(newEducationPlan);

            educationPlan = await _unitOfWork.EducationPlans.UpdateAsync(educationPlan);
            return _mapper.Map<DataAccess.Entities.EducationPlan, EducationPlan>(educationPlan);
        }

        public async Task<EducationPlan[]> UpdateRangeEducationPlanAsync(EducationPlan[] newEducationPlan)
        {
            DataAccess.Entities.EducationPlan[] educationPlan =
                _mapper.Map<EducationPlan[], DataAccess.Entities.EducationPlan[]>(newEducationPlan);

            educationPlan = await _unitOfWork.EducationPlans.UpdateRangeAsync(educationPlan);
            return _mapper.Map<DataAccess.Entities.EducationPlan[], EducationPlan[]>(educationPlan);
        }

        public async Task DeleteEducationPlanAsync(EducationPlan educationPlan)
        {
            DataAccess.Entities.EducationPlan mappedEducationPlan =
                _mapper.Map<EducationPlan, DataAccess.Entities.EducationPlan>(educationPlan);

            await _unitOfWork.EducationPlans.DeleteAsync(mappedEducationPlan);
        }

        public async Task DeleteRangeEducationPlanAsync(EducationPlan[] educationPlans)
        {
            DataAccess.Entities.EducationPlan[] mappedEducationPlans =
                _mapper.Map<EducationPlan[], DataAccess.Entities.EducationPlan[]>(educationPlans);

            await _unitOfWork.EducationPlans.DeleteRangeAsync(mappedEducationPlans);
        }
    }
}