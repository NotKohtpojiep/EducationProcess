using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class AudienceTypeRepository : RepositoryBase<AudienceType>, IAudienceTypeRepository
    {
        private readonly EducationProcessContext _context;
        
        public AudienceTypeRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}