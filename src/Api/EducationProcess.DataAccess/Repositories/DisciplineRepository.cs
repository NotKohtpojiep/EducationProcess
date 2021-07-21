using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class DisciplineRepository : RepositoryBase<Discipline>, IDisciplineRepository
    {
        private readonly EducationProcessContext context;
        
        public DisciplineRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}