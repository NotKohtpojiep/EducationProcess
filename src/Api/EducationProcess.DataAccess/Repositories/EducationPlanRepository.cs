using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationPlanRepository : RepositoryBase<EducationPlan>, IEducationPlanRepository
    {
        private readonly EducationProcessContext context;
        
        public EducationPlanRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}