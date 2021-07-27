using System;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IScheduleDisciplineRepository : IRepositoryBase<ScheduleDiscipline>
    {
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDate(DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupId(int groupId);
    }
}