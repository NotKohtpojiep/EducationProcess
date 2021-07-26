using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class IntermediateCertificationFormRepository : RepositoryBase<IntermediateCertificationForm>, IIntermediateCertificationFormRepository
    {
        private readonly EducationProcessContext _context;
        
        public IntermediateCertificationFormRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}