using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class SemesterDisciplineRepository : RepositoryBase<SemesterDiscipline>, ISemesterDisciplineRepository
    {
        private readonly EducationProcessContext _context;

        public SemesterDisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}