using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EmployeeCathedraRepository : RepositoryBase<EmployeeCathedra>, IEmployeeCathedraRepository
    {
        private readonly EducationProcessContext _context;
        
        public EmployeeCathedraRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}