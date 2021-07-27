using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ScheduleDisciplineService : IScheduleDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleDisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ScheduleDiscipline> GetScheduleDisciplineById(int scheduleDisciplineId)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                await _unitOfWork.ScheduleDisciplines.GetFirstWhereAsync(x => x.ScheduleDisciplineId == scheduleDisciplineId);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task<ScheduleDiscipline> AddScheduleDiscipline(ScheduleDiscipline newScheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(newScheduleDiscipline);

            scheduleDiscipline = await _unitOfWork.ScheduleDisciplines.InsertAsync(scheduleDiscipline);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task<ScheduleDiscipline> UpdateScheduleDiscipline(ScheduleDiscipline newScheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(newScheduleDiscipline);

            scheduleDiscipline = await _unitOfWork.ScheduleDisciplines.UpdateAsync(scheduleDiscipline);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task DeleteScheduleDiscipline(ScheduleDiscipline scheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline mappedScheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(scheduleDiscipline);

            await _unitOfWork.ScheduleDisciplines.Delete(mappedScheduleDiscipline);
        }
    }
}