using System;
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
                      
        /// <summary>
        /// Получение информации о закрепляемых дисциплинах вместе с информацией о работниках, дисциплины с кафедрой и группы
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>
        /// FixedDisciplines array with
        /// include EmployeeFixer and Post
        /// include FixingEmployee and Post
        /// include SemesterDiscipline and Discipline and Cathedra and Semester
        /// include Group
        /// </returns>
        public async Task<FixedDiscipline[]> GetRangeWithInclude(int offset, int limit)
        {
            return await _context.FixedDisciplines.AsNoTracking()
                .Skip((offset - 1) * limit)
                .Take(limit)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Post)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Post)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.Cathedra)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.Group)
                .ToArrayAsync();
        }

        public async Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithInclude(int fixingEmployeeId)
        {
            return await _context.FixedDisciplines.AsNoTracking()
                .Where(x => x.FixingEmployeeId == fixingEmployeeId)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Post)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Post)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.Cathedra)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.Group)
                .ToArrayAsync();
        }

        public async Task<FixedDiscipline[]> GetAllByGroupIdWithInclude(int groupId)
        {
            return await _context.FixedDisciplines.AsNoTracking()
                .Where(x => x.GroupId == groupId)
                .Include(x => x.EmployeeFixer)
                .ThenInclude(x => x.Post)
                .Include(x => x.FixingEmployee)
                .ThenInclude(x => x.Post)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.Cathedra)
                .Include(x => x.SemesterDiscipline)
                .ThenInclude(x => x.Semester)
                .Include(x => x.Group)
                .ToArrayAsync();
        }
    }
}