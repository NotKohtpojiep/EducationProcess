using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class AudienceRepository : RepositoryBase<Audience>, IAudienceRepository
    {
        private readonly EducationProcessContext context;
        
        public AudienceRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}