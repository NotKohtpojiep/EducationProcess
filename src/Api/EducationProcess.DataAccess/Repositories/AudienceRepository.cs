using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class AudienceRepository : RepositoryBase<Audience>, IAudienceRepository
    {
        private readonly EducationProcessContext _context;
        
        public AudienceRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}