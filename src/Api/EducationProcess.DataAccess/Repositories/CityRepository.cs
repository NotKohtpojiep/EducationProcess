using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        private readonly EducationProcessContext _context;
        
        public CityRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}