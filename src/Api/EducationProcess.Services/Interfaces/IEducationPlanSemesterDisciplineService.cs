using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEducationPlanSemesterDisciplineService
    {
        Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdAsync(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdWithIncludeAsync(int educationPlanId);
        Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineBySemesterDisciplineIdAsync(int semesterDisciplineId);
        Task<EducationPlanSemesterDiscipline[]> GetAllEducationPlanSemesterDisciplinesAsync();
        Task<EducationPlanSemesterDiscipline> AddEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline newEducationPlanSemesterDiscipline);
        Task<EducationPlanSemesterDiscipline[]> AddRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] newEducationPlanSemesterDisciplines);
        Task<EducationPlanSemesterDiscipline> UpdateEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline newEducationPlanSemesterDiscipline);
        Task<EducationPlanSemesterDiscipline[]> UpdateRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] newEducationPlanSemesterDiscipline);
        Task DeleteEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline educationPlanSemesterDiscipline);
        Task DeleteRangeEducationPlanSemesterDisciplineAsync(EducationPlanSemesterDiscipline[] educationPlanSemesterDisciplines);
    }
}