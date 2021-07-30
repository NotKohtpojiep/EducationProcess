using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IFsesCategoryService
    {
        Task<FsesCategory> GetFsesCategoryByIdAsync(int fsesCategoryId);
        Task<FsesCategory[]> GetAllFsesCategoriesAsync();
        Task<FsesCategory> AddFsesCategoryAsync(FsesCategory newFsesCategory);
        Task<FsesCategory[]> AddRangeFsesCategoryAsync(FsesCategory[] newFsesCategories);
        Task<FsesCategory> UpdateFsesCategoryAsync(FsesCategory newFsesCategory);
        Task<FsesCategory[]> UpdateRangeFsesCategoryAsync(FsesCategory[] newFsesCategory);
        Task DeleteFsesCategoryAsync(FsesCategory fsesCategory);
        Task DeleteRangeFsesCategoryAsync(FsesCategory[] fsesCategorys);
    }
}