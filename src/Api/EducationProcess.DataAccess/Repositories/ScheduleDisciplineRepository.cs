using System;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class ScheduleDisciplineRepository : RepositoryBase<ScheduleDiscipline>, IScheduleDisciplineRepository
    {
        private readonly EducationProcessContext _context;

        public ScheduleDisciplineRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}