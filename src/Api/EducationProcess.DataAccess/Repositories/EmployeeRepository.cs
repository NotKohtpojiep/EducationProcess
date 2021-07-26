using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly EducationProcessContext _context;
        
        public EmployeeRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}