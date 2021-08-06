using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AcademicYearService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AcademicYear> GetAcademicYearByIdAsync(int academicYearId)
        {
            DataAccess.Entities.AcademicYear academicYear =
                await _unitOfWork.AcademicYears.GetFirstWhereAsync(x => x.AcademicYearId == academicYearId);
            return _mapper.Map<DataAccess.Entities.AcademicYear, AcademicYear>(academicYear);
        }

        public async Task<AcademicYear[]> GetAllAcademicYearsAsync()
        {
            DataAccess.Entities.AcademicYear[] academicYear =
                await _unitOfWork.AcademicYears.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.AcademicYear[], AcademicYear[]>(academicYear);
        }

        public async Task<AcademicYear> AddAcademicYearAsync(AcademicYear newAcademicYear)
        {
            DataAccess.Entities.AcademicYear academicYear =
                _mapper.Map<AcademicYear, DataAccess.Entities.AcademicYear>(newAcademicYear);

            academicYear = await _unitOfWork.AcademicYears.AddAsync(academicYear);
            return _mapper.Map<DataAccess.Entities.AcademicYear, AcademicYear>(academicYear);
        }

        public async Task<AcademicYear[]> AddRangeAcademicYearAsync(AcademicYear[] newAcademicYears)
        {
            DataAccess.Entities.AcademicYear[] academicYears =
                _mapper.Map<AcademicYear[], DataAccess.Entities.AcademicYear[]>(newAcademicYears);

            academicYears = await _unitOfWork.AcademicYears.AddRangeAsync(academicYears);
            return _mapper.Map<DataAccess.Entities.AcademicYear[], AcademicYear[]>(academicYears);
        }

        public async Task<AcademicYear> UpdateAcademicYearAsync(AcademicYear newAcademicYear)
        {
            DataAccess.Entities.AcademicYear academicYear =
                _mapper.Map<AcademicYear, DataAccess.Entities.AcademicYear>(newAcademicYear);

            academicYear = await _unitOfWork.AcademicYears.UpdateAsync(academicYear);
            return _mapper.Map<DataAccess.Entities.AcademicYear, AcademicYear>(academicYear);
        }

        public async Task<AcademicYear[]> UpdateRangeAcademicYearAsync(AcademicYear[] newAcademicYear)
        {
            DataAccess.Entities.AcademicYear[] academicYear =
                _mapper.Map<AcademicYear[], DataAccess.Entities.AcademicYear[]>(newAcademicYear);

            academicYear = await _unitOfWork.AcademicYears.UpdateRangeAsync(academicYear);
            return _mapper.Map<DataAccess.Entities.AcademicYear[], AcademicYear[]>(academicYear);
        }

        public async Task DeleteAcademicYearAsync(AcademicYear academicYear)
        {
            DataAccess.Entities.AcademicYear mappedAcademicYear =
                _mapper.Map<AcademicYear, DataAccess.Entities.AcademicYear>(academicYear);

            await _unitOfWork.AcademicYears.DeleteAsync(mappedAcademicYear);
        }

        public async Task DeleteRangeAcademicYearAsync(AcademicYear[] academicYears)
        {
            DataAccess.Entities.AcademicYear[] mappedAcademicYears =
                _mapper.Map<AcademicYear[], DataAccess.Entities.AcademicYear[]>(academicYears);

            await _unitOfWork.AcademicYears.DeleteRangeAsync(mappedAcademicYears);
        }
    }
}