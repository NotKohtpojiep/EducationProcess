using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IFixedDisciplineRepository : IRepositoryBase<FixedDiscipline>
    {
        Task<FixedDiscipline[]> GetAllWithInclude();
        Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithInclude(int fixingEmployeeId);
    }
}