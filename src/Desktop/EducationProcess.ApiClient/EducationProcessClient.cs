using System;
using System.Net.Http;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Oauth.Requests;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Internal.Http.Serialization;
using EducationProcess.ApiClient.Internal.Queries;
using EducationProcess.ApiClient.Internal.Utilities;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient
{
    public sealed class EducationProcessClient : IEducationProcessClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;
        public EducationProcessClient(string hostUrl, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null)
        {
            Guard.NotEmpty(hostUrl, nameof(hostUrl));
            Guard.NotNull(authenticationToken, nameof(authenticationToken));
            HostUrl = FixBaseUrl(hostUrl);

            var jsonSerializer = new RequestsJsonSerializer();

            _httpFacade = new EducationProcessHttpFacade(
                HostUrl,
                jsonSerializer,
                authenticationToken,
                httpMessageHandler,
                clientTimeout);

            Connection = new ConnectionClient(_httpFacade);
        }

        public ConnectionClient Connection { get; }

        public string HostUrl { get; }

        public Task<AccessTokenResponse> LoginAsync(string username, string password, string scope = "api")
        {
            Guard.NotEmpty(username, nameof(username));
            Guard.NotEmpty(password, nameof(password));
            var accessTokenRequest = new AccessTokenRequest
            {
                GrantType = "password",
                Scope = scope,
                Username = username,
                Password = password
            };
            return _httpFacade.LoginAsync(accessTokenRequest);
        }

        private static string FixBaseUrl(string url)
        {
            url = url.TrimEnd('/');

            if (!url.EndsWith("/api", StringComparison.OrdinalIgnoreCase))
                url += "/api";

            return url + "/";
        }
    }
}