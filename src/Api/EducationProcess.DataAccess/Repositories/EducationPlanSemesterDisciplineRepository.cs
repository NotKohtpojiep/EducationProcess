using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationPlanSemesterDisciplineRepository : RepositoryBase<EducationPlanSemesterDiscipline>, IEducationPlanSemesterDisciplineRepository
    {
        private readonly EducationProcessContext context;
        
        public EducationPlanSemesterDisciplineRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}