using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class FsesCategoryRepository : RepositoryBase<FsesCategory>, IFsesCategoryRepository
    {
        private readonly EducationProcessContext _context;
        
        public FsesCategoryRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}