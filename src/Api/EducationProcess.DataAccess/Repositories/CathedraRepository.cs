using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class CathedraRepository : RepositoryBase<Cathedra>, ICathedraRepository
    {
        private readonly EducationProcessContext _context;
        
        public CathedraRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}