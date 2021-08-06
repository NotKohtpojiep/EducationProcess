using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEducationFormService
    {
        Task<EducationForm> GetEducationFormByIdAsync(int educationFormId);
        Task<EducationForm[]> GetAllEducationFormsAsync();
        Task<EducationForm> AddEducationFormAsync(EducationForm newEducationForm);
        Task<EducationForm[]> AddRangeEducationFormAsync(EducationForm[] newEducationForms);
        Task<EducationForm> UpdateEducationFormAsync(EducationForm newEducationForm);
        Task<EducationForm[]> UpdateRangeEducationFormAsync(EducationForm[] newEducationForm);
        Task DeleteEducationFormAsync(EducationForm educationForm);
        Task DeleteRangeEducationFormAsync(EducationForm[] educationForms);
    }
}