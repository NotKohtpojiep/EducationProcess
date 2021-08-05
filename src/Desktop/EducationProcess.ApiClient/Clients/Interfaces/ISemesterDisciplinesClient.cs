using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Requests;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface ISemesterDisciplinesClient
    {
        Task<SemesterDiscipline> GetSemesterDisciplineAsync(int semesterDisciplineId);
        Task<SemesterDiscipline[]> GetAllSemesterDisciplinesAsync();

        Task<SemesterDiscipline> CreateSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline);
        Task<SemesterDiscipline[]> CreateSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines);

        Task<SemesterDiscipline> UpdateSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline);
        Task<SemesterDiscipline[]> UpdateSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines);

        Task DeleteSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline);
        Task DeleteSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines);
    }
}