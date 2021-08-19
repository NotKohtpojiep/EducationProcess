using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IDisciplineRepository : IRepositoryBase<Discipline>
    {
        Task<Discipline[]> GetAllWithInclude();
    }
}