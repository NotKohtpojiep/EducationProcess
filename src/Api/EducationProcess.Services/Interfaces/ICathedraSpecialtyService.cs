using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ICathedraSpecialtyService
    {
        Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesByCathedraIdAsync(int cathedraId);
        Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesBySpecialtyIdAsync(int fsesCategoryPatitionId);
        Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesAsync();
        Task<CathedraSpecialty> AddCathedraSpecialtyAsync(CathedraSpecialty newCathedraSpecialty);
        Task<CathedraSpecialty[]> AddRangeCathedraSpecialtyAsync(CathedraSpecialty[] newCathedraSpecialties);
        Task<CathedraSpecialty> UpdateCathedraSpecialtyAsync(CathedraSpecialty newCathedraSpecialty);
        Task<CathedraSpecialty[]> UpdateRangeCathedraSpecialtyAsync(CathedraSpecialty[] newCathedraSpecialty);
        Task DeleteCathedraSpecialtyAsync(CathedraSpecialty cathedraSpecialty);
        Task DeleteRangeCathedraSpecialtyAsync(CathedraSpecialty[] cathedraSpecialtys);
    }
}