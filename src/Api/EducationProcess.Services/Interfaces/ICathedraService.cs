using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ICathedraService
    {
        Task<Cathedra> GetCathedraByIdAsync(int cathedraId);
        Task<Cathedra[]> GetAllCathedrasAsync();
        Task<Cathedra> AddCathedraAsync(Cathedra newCathedra);
        Task<Cathedra[]> AddRangeCathedraAsync(Cathedra[] newCathedras);
        Task<Cathedra> UpdateCathedraAsync(Cathedra newCathedra);
        Task<Cathedra[]> UpdateRangeCathedraAsync(Cathedra[] newCathedra);
        Task DeleteCathedraAsync(Cathedra cathedra);
        Task DeleteRangeCathedraAsync(Cathedra[] cathedras);
    }
}