using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class StreetRepository : RepositoryBase<Street>, IStreetRepository
    {
        private readonly EducationProcessContext _context;
        
        public StreetRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}