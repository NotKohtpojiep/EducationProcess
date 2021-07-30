using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        private readonly EducationProcessContext _context;
        
        public RegionRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}