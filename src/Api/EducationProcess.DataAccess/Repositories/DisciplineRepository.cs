using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.DataAccess.Repositories
{
    public class DisciplineRepository : RepositoryBase<Discipline>, IDisciplineRepository
    {
        private readonly EducationProcessContext _context;
        
        public DisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Discipline[]> GetAllWithInclude()
        {
           return await _context.Disciplines.AsNoTracking()
               .Include(x => x.Cathedra)
               .Include(x => x.EducationCycle)
               .ToArrayAsync();
        }
    }
}