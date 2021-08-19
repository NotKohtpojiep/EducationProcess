using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface ISemesterDisciplineService
    {
        Task<SemesterDiscipline[]> GetAllSemesterDisciplines();
        Task<SemesterDiscipline> CreateSemesterDiscipline(SemesterDiscipline semesterDiscipline);
    }
}
