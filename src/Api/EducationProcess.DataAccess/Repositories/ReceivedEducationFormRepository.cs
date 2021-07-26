using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ReceivedEducationFormRepository : RepositoryBase<ReceivedEducationForm>, IReceivedEducationFormRepository
    {
        private readonly EducationProcessContext _context;
        
        public ReceivedEducationFormRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}