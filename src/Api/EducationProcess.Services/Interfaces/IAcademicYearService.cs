using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IAcademicYearService
    {
        Task<AcademicYear> GetAcademicYearByIdAsync(int academicYearId);
        Task<AcademicYear[]> GetAllAcademicYearsAsync();
        Task<AcademicYear> AddAcademicYearAsync(AcademicYear newAcademicYear);
        Task<AcademicYear[]> AddRangeAcademicYearAsync(AcademicYear[] newAcademicYears);
        Task<AcademicYear> UpdateAcademicYearAsync(AcademicYear newAcademicYear);
        Task<AcademicYear[]> UpdateRangeAcademicYearAsync(AcademicYear[] newAcademicYear);
        Task DeleteAcademicYearAsync(AcademicYear academicYear);
        Task DeleteRangeAcademicYearAsync(AcademicYear[] academicYears);
    }
}