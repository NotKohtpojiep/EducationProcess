using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SemesterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Semester> GetSemesterByIdAsync(int semesterId)
        {
            DataAccess.Entities.Semester semester =
                await _unitOfWork.Semesters.GetFirstWhereAsync(x => x.SemesterId == semesterId);
            return _mapper.Map<DataAccess.Entities.Semester, Semester>(semester);
        }

        public async Task<Semester[]> GetAllSemestersAsync()
        {
            DataAccess.Entities.Semester[] semester =
                await _unitOfWork.Semesters.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Semester[], Semester[]>(semester);
        }

        public async Task<Semester> AddSemesterAsync(Semester newSemester)
        {
            DataAccess.Entities.Semester semester =
                _mapper.Map<Semester, DataAccess.Entities.Semester>(newSemester);

            semester = await _unitOfWork.Semesters.AddAsync(semester);
            return _mapper.Map<DataAccess.Entities.Semester, Semester>(semester);
        }

        public async Task<Semester[]> AddRangeSemesterAsync(Semester[] newSemesters)
        {
            DataAccess.Entities.Semester[] semesters =
                _mapper.Map<Semester[], DataAccess.Entities.Semester[]>(newSemesters);

            semesters = await _unitOfWork.Semesters.AddRangeAsync(semesters);
            return _mapper.Map<DataAccess.Entities.Semester[], Semester[]>(semesters);
        }

        public async Task<Semester> UpdateSemesterAsync(Semester newSemester)
        {
            DataAccess.Entities.Semester semester =
                _mapper.Map<Semester, DataAccess.Entities.Semester>(newSemester);

            semester = await _unitOfWork.Semesters.UpdateAsync(semester);
            return _mapper.Map<DataAccess.Entities.Semester, Semester>(semester);
        }

        public async Task<Semester[]> UpdateRangeSemesterAsync(Semester[] newSemester)
        {
            DataAccess.Entities.Semester[] semester =
                _mapper.Map<Semester[], DataAccess.Entities.Semester[]>(newSemester);

            semester = await _unitOfWork.Semesters.UpdateRangeAsync(semester);
            return _mapper.Map<DataAccess.Entities.Semester[], Semester[]>(semester);
        }

        public async Task DeleteSemesterAsync(Semester semester)
        {
            DataAccess.Entities.Semester mappedSemester =
                _mapper.Map<Semester, DataAccess.Entities.Semester>(semester);

            await _unitOfWork.Semesters.DeleteAsync(mappedSemester);
        }

        public async Task DeleteRangeSemesterAsync(Semester[] semesters)
        {
            DataAccess.Entities.Semester[] mappedSemesters =
                _mapper.Map<Semester[], DataAccess.Entities.Semester[]>(semesters);

            await _unitOfWork.Semesters.DeleteRangeAsync(mappedSemesters);
        }
    }
}