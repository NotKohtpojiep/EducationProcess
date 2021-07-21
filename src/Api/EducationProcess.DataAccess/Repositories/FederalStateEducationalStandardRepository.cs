using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class FederalStateEducationalStandardRepository : RepositoryBase<FederalStateEducationalStandard>, IFederalStateEducationalStandardRepository
    {
        private readonly EducationProcessContext context;
        
        public FederalStateEducationalStandardRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}