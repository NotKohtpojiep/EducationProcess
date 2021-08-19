using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IEducationPlanSemesterDisciplinesClient
    {
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdAsync(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithIncludeAsync(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesBySemesterDisciplineIdAsync(int semesterDisciplineId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesAsync();
    }
}