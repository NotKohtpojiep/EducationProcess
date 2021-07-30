using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ScheduleDisciplineReplacementService : IScheduleDisciplineReplacementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleDisciplineReplacementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ScheduleDisciplineReplacement> GetScheduleDisciplineReplacementByIdAsync(int scheduleDisciplineReplacementId)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement scheduleDisciplineReplacement =
                await _unitOfWork.ScheduleDisciplineReplacements.GetFirstWhereAsync(x => x.ScheduleDisciplineReplacementId == scheduleDisciplineReplacementId);
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement, ScheduleDisciplineReplacement>(scheduleDisciplineReplacement);
        }

        public async Task<ScheduleDisciplineReplacement[]> GetAllScheduleDisciplineReplacementsAsync()
        {
            DataAccess.Entities.ScheduleDisciplineReplacement[] scheduleDisciplineReplacement =
                await _unitOfWork.ScheduleDisciplineReplacements.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement[], ScheduleDisciplineReplacement[]>(scheduleDisciplineReplacement);
        }

        public async Task<ScheduleDisciplineReplacement> AddScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement newScheduleDisciplineReplacement)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement scheduleDisciplineReplacement =
                _mapper.Map<ScheduleDisciplineReplacement, DataAccess.Entities.ScheduleDisciplineReplacement>(newScheduleDisciplineReplacement);

            scheduleDisciplineReplacement = await _unitOfWork.ScheduleDisciplineReplacements.AddAsync(scheduleDisciplineReplacement);
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement, ScheduleDisciplineReplacement>(scheduleDisciplineReplacement);
        }

        public async Task<ScheduleDisciplineReplacement[]> AddRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] newScheduleDisciplineReplacements)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement[] scheduleDisciplineReplacements =
                _mapper.Map<ScheduleDisciplineReplacement[], DataAccess.Entities.ScheduleDisciplineReplacement[]>(newScheduleDisciplineReplacements);

            scheduleDisciplineReplacements = await _unitOfWork.ScheduleDisciplineReplacements.AddRangeAsync(scheduleDisciplineReplacements);
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement[], ScheduleDisciplineReplacement[]>(scheduleDisciplineReplacements);
        }

        public async Task<ScheduleDisciplineReplacement> UpdateScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement newScheduleDisciplineReplacement)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement scheduleDisciplineReplacement =
                _mapper.Map<ScheduleDisciplineReplacement, DataAccess.Entities.ScheduleDisciplineReplacement>(newScheduleDisciplineReplacement);

            scheduleDisciplineReplacement = await _unitOfWork.ScheduleDisciplineReplacements.UpdateAsync(scheduleDisciplineReplacement);
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement, ScheduleDisciplineReplacement>(scheduleDisciplineReplacement);
        }

        public async Task<ScheduleDisciplineReplacement[]> UpdateRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] newScheduleDisciplineReplacement)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement[] scheduleDisciplineReplacement =
                _mapper.Map<ScheduleDisciplineReplacement[], DataAccess.Entities.ScheduleDisciplineReplacement[]>(newScheduleDisciplineReplacement);

            scheduleDisciplineReplacement = await _unitOfWork.ScheduleDisciplineReplacements.UpdateRangeAsync(scheduleDisciplineReplacement);
            return _mapper.Map<DataAccess.Entities.ScheduleDisciplineReplacement[], ScheduleDisciplineReplacement[]>(scheduleDisciplineReplacement);
        }

        public async Task DeleteScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement scheduleDisciplineReplacement)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement mappedScheduleDisciplineReplacement =
                _mapper.Map<ScheduleDisciplineReplacement, DataAccess.Entities.ScheduleDisciplineReplacement>(scheduleDisciplineReplacement);

            await _unitOfWork.ScheduleDisciplineReplacements.DeleteAsync(mappedScheduleDisciplineReplacement);
        }

        public async Task DeleteRangeScheduleDisciplineReplacementAsync(ScheduleDisciplineReplacement[] scheduleDisciplineReplacements)
        {
            DataAccess.Entities.ScheduleDisciplineReplacement[] mappedScheduleDisciplineReplacements =
                _mapper.Map<ScheduleDisciplineReplacement[], DataAccess.Entities.ScheduleDisciplineReplacement[]>(scheduleDisciplineReplacements);

            await _unitOfWork.ScheduleDisciplineReplacements.DeleteRangeAsync(mappedScheduleDisciplineReplacements);
        }
    }
}