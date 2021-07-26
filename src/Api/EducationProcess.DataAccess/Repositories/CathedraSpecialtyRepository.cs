using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class CathedraSpecialtyRepository : RepositoryBase<CathedraSpecialty>, ICathedraSpecialtyRepository
    {
        private readonly EducationProcessContext _context;
        
        public CathedraSpecialtyRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}