using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.ReceivedEducations.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IReceivedEducationsClient
    {
        Task<ReceivedEducation> GetReceivedEducationAsync(int receivedEducationId);
        Task<ReceivedEducation[]> GetAllReceivedEducationsAsync();
    }
}