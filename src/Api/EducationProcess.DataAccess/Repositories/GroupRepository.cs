using System;
using System.Linq;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.DataAccess.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        private readonly EducationProcessContext _context;
        
        public GroupRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Group[]> GetAllCurrentGroupsByDate(DateTime date)
        {
            return await _context.Groups
                .Where(x => x.ReceiptYear <= date.Year && 
                            x.ReceivedEducation.StudyPeriodMonths >= (date.Year - x.ReceiptYear) * 12 + date.Month)
                .ToArrayAsync();
        }
    }
}