using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IReceivedEducationFormService
    {
        Task<ReceivedEducationForm> GetReceivedEducationFormByIdAsync(int receivedEducationFormId);
        Task<ReceivedEducationForm[]> GetAllReceivedEducationFormsAsync();
        Task<ReceivedEducationForm> AddReceivedEducationFormAsync(ReceivedEducationForm newReceivedEducationForm);
        Task<ReceivedEducationForm[]> AddRangeReceivedEducationFormAsync(ReceivedEducationForm[] newReceivedEducationForms);
        Task<ReceivedEducationForm> UpdateReceivedEducationFormAsync(ReceivedEducationForm newReceivedEducationForm);
        Task<ReceivedEducationForm[]> UpdateRangeReceivedEducationFormAsync(ReceivedEducationForm[] newReceivedEducationForm);
        Task DeleteReceivedEducationFormAsync(ReceivedEducationForm receivedEducationForm);
        Task DeleteRangeReceivedEducationFormAsync(ReceivedEducationForm[] receivedEducationForms);
    }
}