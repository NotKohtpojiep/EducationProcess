using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationCyclesAndModuleRepository : RepositoryBase<EducationCyclesAndModule>, IEducationCyclesAndModuleRepository
    {
        private readonly EducationProcessContext context;
        
        public EducationCyclesAndModuleRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}