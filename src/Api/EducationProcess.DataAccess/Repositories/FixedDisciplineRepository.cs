using System.Linq;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.DataAccess.Repositories
{
    public class FixedDisciplineRepository : RepositoryBase<FixedDiscipline>, IFixedDisciplineRepository
    {
        private readonly EducationProcessContext _context;
        
        public FixedDisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FixedDiscipline[]> GetAllWithInclude()
        {
            //TODO: Решить проблему с подключаемыми сущностями. Какие нужны, а какие нет
            return await _context.FixedDisciplines.AsNoTracking()
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Department)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Post)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Department)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Post)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.EducationCycle)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.Cathedra)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.CertificationForm)
                .Include(x => x.Group)
                .ThenInclude(x => x.Curator)
                .Include(x => x.Group)
                .ThenInclude(x => x.ReceivedEducation)
                .ThenInclude(x => x.EducationLevel)
                .ToArrayAsync();
        }

        public async Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithInclude(int fixingEmployeeId)
        {
            //TODO: Решить проблему с подключаемыми сущностями. Какие нужны, а какие нет
            return await _context.FixedDisciplines.AsNoTracking()
                .Where(x => x.FixingEmployeeId == fixingEmployeeId)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Department)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Post)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Department)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Post)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.EducationCycle)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.Cathedra)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.CertificationForm)
                .Include(x => x.Group)
                .ThenInclude(x => x.Curator)
                .Include(x => x.Group)
                .ThenInclude(x => x.ReceivedEducation)
                .ThenInclude(x => x.EducationLevel)
                .ToArrayAsync();
        }
    }
}