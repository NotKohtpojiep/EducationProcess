using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Disciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IDisciplineService
    {
        Task<Discipline[]> GetAllDisciplines();
        Task<Discipline> CreateDiscipline(Discipline discipline);
    }
}
