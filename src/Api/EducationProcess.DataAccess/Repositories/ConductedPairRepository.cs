using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ConductedPairRepository : RepositoryBase<ConductedPair>, IConductedPairRepository
    {
        private readonly EducationProcessContext _context;
        
        public ConductedPairRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}