using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Cathedras.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface ICathedrasClient
    {
        Task<Cathedra> GetCathedraAsync(int cathedraId);
        Task<Cathedra[]> GetAllCathedrasAsync();
    }
}