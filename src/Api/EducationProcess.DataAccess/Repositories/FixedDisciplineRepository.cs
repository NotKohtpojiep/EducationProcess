using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class FixedDisciplineRepository : RepositoryBase<FixedDiscipline>, IFixedDisciplineRepository
    {
        private readonly EducationProcessContext context;
        
        public FixedDisciplineRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}