using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IFixedDisciplineService
    {
        Task<FixedDiscipline> GetFixedDisciplineByIdAsync(int fixedDisciplineId);
        Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync();
        Task<FixedDiscipline> AddFixedDisciplineAsync(FixedDiscipline newFixedDiscipline);
        Task<FixedDiscipline[]> AddRangeFixedDisciplineAsync(FixedDiscipline[] newFixedDisciplines);
        Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDiscipline newFixedDiscipline);
        Task<FixedDiscipline[]> UpdateRangeFixedDisciplineAsync(FixedDiscipline[] newFixedDiscipline);
        Task DeleteFixedDisciplineAsync(FixedDiscipline fixedDiscipline);
        Task DeleteRangeFixedDisciplineAsync(FixedDiscipline[] fixedDisciplines);
    }
}