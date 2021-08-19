using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IEducationPlanSemesterDisciplineService
    {
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanId(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithInclude(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesBySemesterDisciplineId(int semesterDisciplineId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplines();
    }
}
