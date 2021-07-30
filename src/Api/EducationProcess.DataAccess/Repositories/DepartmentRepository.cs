using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private readonly EducationProcessContext _context;
        
        public DepartmentRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}