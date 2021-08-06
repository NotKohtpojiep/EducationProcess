using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class SemesterDisciplineService : ISemesterDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SemesterDisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SemesterDiscipline> GetSemesterDisciplineByIdAsync(int semesterDisciplineId)
        {
            DataAccess.Entities.SemesterDiscipline semesterDiscipline =
                await _unitOfWork.SemesterDisciplines.GetFirstWhereAsync(x => x.SemesterDisciplineId == semesterDisciplineId);
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline, SemesterDiscipline>(semesterDiscipline);
        }

        public async Task<SemesterDiscipline[]> GetAllSemesterDisciplinesAsync()
        {
            DataAccess.Entities.SemesterDiscipline[] semesterDiscipline =
                await _unitOfWork.SemesterDisciplines.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline[], SemesterDiscipline[]>(semesterDiscipline);
        }

        public async Task<SemesterDiscipline> AddSemesterDisciplineAsync(SemesterDiscipline newSemesterDiscipline)
        {
            DataAccess.Entities.SemesterDiscipline semesterDiscipline =
                _mapper.Map<SemesterDiscipline, DataAccess.Entities.SemesterDiscipline>(newSemesterDiscipline);

            semesterDiscipline = await _unitOfWork.SemesterDisciplines.AddAsync(semesterDiscipline);
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline, SemesterDiscipline>(semesterDiscipline);
        }

        public async Task<SemesterDiscipline[]> AddRangeSemesterDisciplineAsync(SemesterDiscipline[] newSemesterDisciplines)
        {
            DataAccess.Entities.SemesterDiscipline[] semesterDisciplines =
                _mapper.Map<SemesterDiscipline[], DataAccess.Entities.SemesterDiscipline[]>(newSemesterDisciplines);

            semesterDisciplines = await _unitOfWork.SemesterDisciplines.AddRangeAsync(semesterDisciplines);
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline[], SemesterDiscipline[]>(semesterDisciplines);
        }

        public async Task<SemesterDiscipline> UpdateSemesterDisciplineAsync(SemesterDiscipline newSemesterDiscipline)
        {
            DataAccess.Entities.SemesterDiscipline semesterDiscipline =
                _mapper.Map<SemesterDiscipline, DataAccess.Entities.SemesterDiscipline>(newSemesterDiscipline);

            semesterDiscipline = await _unitOfWork.SemesterDisciplines.UpdateAsync(semesterDiscipline);
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline, SemesterDiscipline>(semesterDiscipline);
        }

        public async Task<SemesterDiscipline[]> UpdateRangeSemesterDisciplineAsync(SemesterDiscipline[] newSemesterDiscipline)
        {
            DataAccess.Entities.SemesterDiscipline[] semesterDiscipline =
                _mapper.Map<SemesterDiscipline[], DataAccess.Entities.SemesterDiscipline[]>(newSemesterDiscipline);

            semesterDiscipline = await _unitOfWork.SemesterDisciplines.UpdateRangeAsync(semesterDiscipline);
            return _mapper.Map<DataAccess.Entities.SemesterDiscipline[], SemesterDiscipline[]>(semesterDiscipline);
        }

        public async Task DeleteSemesterDisciplineAsync(SemesterDiscipline semesterDiscipline)
        {
            DataAccess.Entities.SemesterDiscipline mappedSemesterDiscipline =
                _mapper.Map<SemesterDiscipline, DataAccess.Entities.SemesterDiscipline>(semesterDiscipline);

            await _unitOfWork.SemesterDisciplines.DeleteAsync(mappedSemesterDiscipline);
        }

        public async Task DeleteRangeSemesterDisciplineAsync(SemesterDiscipline[] semesterDisciplines)
        {
            DataAccess.Entities.SemesterDiscipline[] mappedSemesterDisciplines =
                _mapper.Map<SemesterDiscipline[], DataAccess.Entities.SemesterDiscipline[]>(semesterDisciplines);

            await _unitOfWork.SemesterDisciplines.DeleteRangeAsync(mappedSemesterDisciplines);
        }
    }
}