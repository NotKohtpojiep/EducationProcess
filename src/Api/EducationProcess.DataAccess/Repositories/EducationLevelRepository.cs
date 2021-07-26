using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationLevelRepository : RepositoryBase<EducationLevel>, IEducationLevelRepository
    {
        private readonly EducationProcessContext _context;
        
        public EducationLevelRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}