using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient
{
    public interface IEducationProcessClient
    {
        string HostUrl { get; }

        Task<AccessTokenResponse> LoginAsync(string username, string password, string scope = "api");
    }
}