using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.FixedDisciplines.Requests;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IFixedDisciplinesClient
    {
        Task<FixedDiscipline> GetFixedDisciplineAsync(int fixedDisciplineId);
        Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync();
        Task<FixedDiscipline[]> GetAllFixedDisciplinesWithIncludeAsync();

        Task<FixedDiscipline> CreateFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline);
        Task<FixedDiscipline[]> CreateFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines);

        Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline);
        Task<FixedDiscipline[]> UpdateFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines);

        Task DeleteFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline);
        Task DeleteFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines);
    }
}