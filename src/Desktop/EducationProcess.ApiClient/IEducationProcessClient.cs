using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient
{
    public interface IEducationProcessClient
    {
        ISchedulesClient Issues { get; }
        IPostsClient Posts { get; }

        string HostUrl { get; }

        Task<AccessTokenResponse> LoginAsync(string username, string password, string scope = "api");
    }
}