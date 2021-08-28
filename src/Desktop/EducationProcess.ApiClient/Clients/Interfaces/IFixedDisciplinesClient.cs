using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.FixedDisciplines.Requests;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IFixedDisciplinesClient
    {
        Task<FixedDiscipline> GetAsync(int fixedDisciplineId);
        Task<FixedDiscipline[]> GetAllAsync();
        Task<FixedDiscipline[]> GetAllWithIncludeAsync(int pageNumber = 1, int pageSize = 10);
        Task<FixedDiscipline[]> GetAllByTeacherIdWithIncludeAsync(int teacherId);
        Task<FixedDiscipline[]> GetAllByGroupIdWithIncludeAsync(int teacherId);
        Task<int> GetCount();

        Task<FixedDiscipline> CreateAsync(FixedDisciplineRequest fixedDiscipline);
        Task<FixedDiscipline[]> CreateArrayAsync(FixedDisciplineRequest[] fixedDisciplines);

        Task<FixedDiscipline> UpdateAsync(FixedDisciplineRequest fixedDiscipline);
        Task<FixedDiscipline[]> UpdateArrayAsync(FixedDisciplineRequest[] fixedDisciplines);

        Task DeleteAsync(FixedDisciplineRequest fixedDiscipline);
        Task DeleteArrayAsync(FixedDisciplineRequest[] fixedDisciplines);
    }
}