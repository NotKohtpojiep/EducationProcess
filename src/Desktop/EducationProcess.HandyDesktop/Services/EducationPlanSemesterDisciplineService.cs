using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public class EducationPlanSemesterDisciplineService : IEducationPlanSemesterDisciplineService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public EducationPlanSemesterDisciplineService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanId(int educationPlanId)
        {
            return await _educationProcessClient.EducationPlanSemesterDisciplines.GetAllEducationPlanSemesterDisciplinesByEducationPlanIdAsync(educationPlanId);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithInclude(int educationPlanId)
        {
            return await _educationProcessClient.EducationPlanSemesterDisciplines.GetAllEducationPlanSemesterDisciplinesByEducationPlanIdWithIncludeAsync(educationPlanId);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesBySemesterDisciplineId(int semesterDisciplineId)
        {
            return await _educationProcessClient.EducationPlanSemesterDisciplines.GetAllEducationPlanSemesterDisciplinesBySemesterDisciplineIdAsync(semesterDisciplineId);
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplines()
        {
            return await _educationProcessClient.EducationPlanSemesterDisciplines.GetAllEducationPlanSemesterDisciplinesAsync();
        }
    }
}
