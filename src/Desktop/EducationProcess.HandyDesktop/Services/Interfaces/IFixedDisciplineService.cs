using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IFixedDisciplineService
    {
        Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync();
        Task<FixedDiscipline> CreateFixedDisciplineAsync(FixedDiscipline fixedDiscipline);
        Task<FixedDiscipline[]> CreateFixedDisciplineArrayAsync(FixedDiscipline[] fixedDisciplines);
        Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDiscipline fixedDiscipline);
        Task<FixedDiscipline[]> UpdateFixedDisciplineArray(FixedDiscipline[] fixedDisciplines);
    }
}
