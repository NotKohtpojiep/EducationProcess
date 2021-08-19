using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IDisciplineService
    {
        Task<Discipline> GetDisciplineByIdAsync(int disciplineId);
        Task<Discipline[]> GetAllDisciplinesAsync();
        Task<Discipline[]> GetAllDisciplinesWithIncludeAsync();
        Task<Discipline> AddDisciplineAsync(Discipline newDiscipline);
        Task<Discipline[]> AddRangeDisciplineAsync(Discipline[] newDisciplines);
        Task<Discipline> UpdateDisciplineAsync(Discipline newDiscipline);
        Task<Discipline[]> UpdateRangeDisciplineAsync(Discipline[] newDiscipline);
        Task DeleteDisciplineAsync(Discipline discipline);
        Task DeleteRangeDisciplineAsync(Discipline[] disciplines);
    }
}