using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ISemesterDisciplineService
    {
        Task<SemesterDiscipline> GetSemesterDisciplineByIdAsync(int semesterDisciplineId);
        Task<SemesterDiscipline[]> GetAllSemesterDisciplinesAsync();
        Task<SemesterDiscipline> AddSemesterDisciplineAsync(SemesterDiscipline newSemesterDiscipline);
        Task<SemesterDiscipline[]> AddRangeSemesterDisciplineAsync(SemesterDiscipline[] newSemesterDisciplines);
        Task<SemesterDiscipline> UpdateSemesterDisciplineAsync(SemesterDiscipline newSemesterDiscipline);
        Task<SemesterDiscipline[]> UpdateRangeSemesterDisciplineAsync(SemesterDiscipline[] newSemesterDiscipline);
        Task DeleteSemesterDisciplineAsync(SemesterDiscipline semesterDiscipline);
        Task DeleteRangeSemesterDisciplineAsync(SemesterDiscipline[] semesterDisciplines);
    }
}