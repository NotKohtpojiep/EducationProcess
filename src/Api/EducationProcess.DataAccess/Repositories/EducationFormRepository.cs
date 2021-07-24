using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationFormRepository : RepositoryBase<EducationForm>, IEducationFormRepository
    {
        private readonly EducationProcessContext context;
        
        public EducationFormRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}