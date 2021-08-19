using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IEducationPlanSemesterDisciplineRepository : IRepositoryBase<EducationPlanSemesterDiscipline>
    {
        Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdWithIncludeAsync(int educationPlanId);
    }
}