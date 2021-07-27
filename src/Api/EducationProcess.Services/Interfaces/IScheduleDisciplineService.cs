using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IScheduleDisciplineService
    {
        Task<ScheduleDiscipline> GetScheduleDisciplineById(int scheduleDisciplineId);
        Task<ScheduleDiscipline> AddScheduleDiscipline(ScheduleDiscipline newScheduleDiscipline);
        Task<ScheduleDiscipline> UpdateScheduleDiscipline(ScheduleDiscipline newScheduleDiscipline);
        Task DeleteScheduleDiscipline(ScheduleDiscipline scheduleDiscipline);
    }
}