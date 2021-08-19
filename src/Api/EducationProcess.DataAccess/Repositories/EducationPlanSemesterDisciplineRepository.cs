using System.Linq;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.DataAccess.Repositories
{
    public class EducationPlanSemesterDisciplineRepository : RepositoryBase<EducationPlanSemesterDiscipline>, IEducationPlanSemesterDisciplineRepository
    {
        private readonly EducationProcessContext _context;
        
        public EducationPlanSemesterDisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EducationPlanSemesterDiscipline[]> GetEducationPlanSemesterDisciplineByEducationPlanIdWithIncludeAsync(int educationPlanId)
        {
            return await _context.EducationPlanSemesterDisciplines.Where(x => x.EducationPlanId == educationPlanId)
                .AsNoTracking()
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.CertificationForm)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.EducationCycle)
                .ToArrayAsync();
        }
    }
}