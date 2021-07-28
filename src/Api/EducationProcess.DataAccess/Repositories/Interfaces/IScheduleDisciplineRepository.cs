using System;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IScheduleDisciplineRepository : IRepositoryBase<ScheduleDiscipline>
    {
        Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdAsync(int groupId);
    }
}