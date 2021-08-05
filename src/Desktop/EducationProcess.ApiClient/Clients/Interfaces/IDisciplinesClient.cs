using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Disciplines.Requests;
using EducationProcess.ApiClient.Models.Disciplines.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IDisciplinesClient
    {
        Task<Discipline> GetDisciplineAsync(int disciplineId);
        Task<Discipline[]> GetAllDisciplinesAsync();

        Task<Discipline> CreateDisciplineAsync(DisciplineRequest discipline);
        Task<Discipline[]> CreateDisciplineArrayAsync(DisciplineRequest[] disciplines);

        Task<Discipline> UpdateDisciplineAsync(DisciplineRequest discipline);
        Task<Discipline[]> UpdateDisciplineArrayAsync(DisciplineRequest[] disciplines);

        Task DeleteDisciplineAsync(DisciplineRequest discipline);
        Task DeleteDisciplineArrayAsync(DisciplineRequest[] disciplines);
    }
}