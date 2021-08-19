using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationPlanSemesterDisciplineService : IEducationPlanSemesterDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationPlanSemesterDisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdAsync(int educationPlanId)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines =
                await _unitOfWork.EducationPlanSemesterDisciplines.FindAllByWhereAsync(x => x.EducationPlanId == educationPlanId);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDisciplines);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdWithIncludeAsync(int educationPlanId)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines =
                await _unitOfWork.EducationPlanSemesterDisciplines.GetEducationPlanSemesterDisciplineByEducationPlanIdWithIncludeAsync(educationPlanId);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDisciplines);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineBySemesterDisciplineIdAsync(int semesterDisciplineId)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines =
                await _unitOfWork.EducationPlanSemesterDisciplines.FindAllByWhereAsync(x => x.SemesterDisciplineId == semesterDisciplineId);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDisciplines);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesAsync()
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDiscipline =
                await _unitOfWork.EducationPlanSemesterDisciplines.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDiscipline);
        }

        public async Task<EducationPlanSemesterDiscipline> AddEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline newEducationPlanSemesterDiscipline)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline educationPlanSemesterDiscipline =
                _mapper.Map<EducationPlanSemesterDiscipline, DataAccess.Entities.EducationPlanSemesterDiscipline>(newEducationPlanSemesterDiscipline);

            educationPlanSemesterDiscipline = await _unitOfWork.EducationPlanSemesterDisciplines.AddAsync(educationPlanSemesterDiscipline);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline, EducationPlanSemesterDiscipline>(educationPlanSemesterDiscipline);
        }

        public async Task<EducationPlanSemesterDiscipline[]> AddRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] newEducationPlanSemesterDisciplines)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines =
                _mapper.Map<EducationPlanSemesterDiscipline[], DataAccess.Entities.EducationPlanSemesterDiscipline[]>(newEducationPlanSemesterDisciplines);

            educationPlanSemesterDisciplines = await _unitOfWork.EducationPlanSemesterDisciplines.AddRangeAsync(educationPlanSemesterDisciplines);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDisciplines);
        }

        public async Task<EducationPlanSemesterDiscipline> UpdateEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline newEducationPlanSemesterDiscipline)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline educationPlanSemesterDiscipline =
                _mapper.Map<EducationPlanSemesterDiscipline, DataAccess.Entities.EducationPlanSemesterDiscipline>(newEducationPlanSemesterDiscipline);

            educationPlanSemesterDiscipline = await _unitOfWork.EducationPlanSemesterDisciplines.UpdateAsync(educationPlanSemesterDiscipline);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline, EducationPlanSemesterDiscipline>(educationPlanSemesterDiscipline);
        }

        public async Task<EducationPlanSemesterDiscipline[]> UpdateRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] newEducationPlanSemesterDiscipline)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] educationPlanSemesterDiscipline =
                _mapper.Map<EducationPlanSemesterDiscipline[], DataAccess.Entities.EducationPlanSemesterDiscipline[]>(newEducationPlanSemesterDiscipline);

            educationPlanSemesterDiscipline = await _unitOfWork.EducationPlanSemesterDisciplines.UpdateRangeAsync(educationPlanSemesterDiscipline);
            return _mapper.Map<DataAccess.Entities.EducationPlanSemesterDiscipline[], EducationPlanSemesterDiscipline[]>(educationPlanSemesterDiscipline);
        }

        public async Task DeleteEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline educationPlanSemesterDiscipline)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline mappedEducationPlanSemesterDiscipline =
                _mapper.Map<EducationPlanSemesterDiscipline, DataAccess.Entities.EducationPlanSemesterDiscipline>(educationPlanSemesterDiscipline);

            await _unitOfWork.EducationPlanSemesterDisciplines.DeleteAsync(mappedEducationPlanSemesterDiscipline);
        }

        public async Task DeleteRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines)
        {
            DataAccess.Entities.EducationPlanSemesterDiscipline[] mappedEducationPlanSemesterDisciplines =
                _mapper.Map<EducationPlanSemesterDiscipline[], DataAccess.Entities.EducationPlanSemesterDiscipline[]>(educationPlanSemesterDisciplines);

            await _unitOfWork.EducationPlanSemesterDisciplines.DeleteRangeAsync(mappedEducationPlanSemesterDisciplines);
        }
    }
}