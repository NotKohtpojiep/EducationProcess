using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ScheduleDisciplineReplacementRepository : RepositoryBase<ScheduleDisciplineReplacement>, IScheduleDisciplineReplacementRepository
    {
        private readonly EducationProcessContext context;
        
        public ScheduleDisciplineReplacementRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}