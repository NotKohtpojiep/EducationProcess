using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ScheduleDisciplineRepository : RepositoryBase<ScheduleDiscipline>, IScheduleDisciplineRepository
    {
        private readonly EducationProcessContext context;
        
        public ScheduleDisciplineRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}