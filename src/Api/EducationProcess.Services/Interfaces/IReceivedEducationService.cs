using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IReceivedEducationService
    {
        Task<ReceivedEducation> GetReceivedEducationByIdAsync(int receivedEducationId);
        Task<ReceivedEducation[]> GetAllReceivedEducationsAsync();
        Task<ReceivedEducation> AddReceivedEducationAsync(ReceivedEducation newReceivedEducation);
        Task<ReceivedEducation[]> AddRangeReceivedEducationAsync(ReceivedEducation[] newReceivedEducations);
        Task<ReceivedEducation> UpdateReceivedEducationAsync(ReceivedEducation newReceivedEducation);
        Task<ReceivedEducation[]> UpdateRangeReceivedEducationAsync(ReceivedEducation[] newReceivedEducation);
        Task DeleteReceivedEducationAsync(ReceivedEducation receivedEducation);
        Task DeleteRangeReceivedEducationAsync(ReceivedEducation[] receivedEducations);
    }
}