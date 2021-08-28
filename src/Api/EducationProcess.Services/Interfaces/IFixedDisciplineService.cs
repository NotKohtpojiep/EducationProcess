using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IFixedDisciplineService
    {
        Task<FixedDiscipline> GetByIdAsync(int fixedDisciplineId);
        Task<FixedDiscipline[]> GetAllAsync();
        Task<FixedDiscipline[]> GetRangeWithIncludeAsync(int offset = 1, int limit = 10);
        Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithIncludeAsync(int fixingEmployeeId);
        Task<FixedDiscipline[]> GetAllByGroupIdWithIncludeAsync(int groupId);
        Task<int> Count();
        Task<FixedDiscipline> AddAsync(FixedDiscipline newFixedDiscipline);
        Task<FixedDiscipline[]> AddRangeAsync(FixedDiscipline[] newFixedDisciplines);
        Task<FixedDiscipline> UpdateAsync(FixedDiscipline newFixedDiscipline);
        Task<FixedDiscipline[]> UpdateRangeAsync(FixedDiscipline[] newFixedDiscipline);
        Task DeleteAsync(FixedDiscipline fixedDiscipline);
        Task DeleteRangeAsync(FixedDiscipline[] fixedDisciplines);
    }
}