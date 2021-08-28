using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IFixedDisciplineService
    {
        Task<FixedDiscipline[]> GetAllAsync();
        Task<FixedDiscipline[]> GetPrettyRangeAsync(int pageNumber = 1, int pageSize = 10);
        Task<FixedDiscipline[]> GetAllByTeacherIdAsync(int teacherId);
        Task<FixedDiscipline[]> GetAllByGroupIdAsync(int teacherId);
        Task<int> GetCount();
        Task<FixedDiscipline> CreateAsync(FixedDiscipline fixedDiscipline);
        Task<FixedDiscipline[]> CreateArrayAsync(FixedDiscipline[] fixedDisciplines);
        Task<FixedDiscipline> UpdateAsync(FixedDiscipline fixedDiscipline);
        Task<FixedDiscipline[]> UpdateArray(FixedDiscipline[] fixedDisciplines);
    }
}
