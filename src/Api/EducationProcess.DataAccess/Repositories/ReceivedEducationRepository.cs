using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ReceivedEducationRepository : RepositoryBase<ReceivedEducation>, IReceivedEducationRepository
    {
        private readonly EducationProcessContext context;
        
        public ReceivedEducationRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}