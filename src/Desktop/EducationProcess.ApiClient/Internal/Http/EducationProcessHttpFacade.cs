using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Oauth.Requests;
using EducationProcess.ApiClient.Internal.Http.Serialization;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient.Internal.Http
{
    internal sealed class EducationProcessHttpFacade
    {
        private readonly HttpClient _httpClient;
        private EducationProcessApiRequestor _requestor;

        private EducationProcessHttpFacade(string hostUrl, RequestsJsonSerializer jsonSerializer, HttpMessageHandler httpMessageHandler, TimeSpan? clientTimeout = null)
        {
            _httpClient = new HttpClient(httpMessageHandler ?? new HttpClientHandler()) { BaseAddress = new Uri(hostUrl) };
            if (clientTimeout.HasValue)
                _httpClient.Timeout = clientTimeout.Value;

            Setup(jsonSerializer);
        }

        public EducationProcessHttpFacade(string hostUrl, RequestsJsonSerializer jsonSerializer, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null) :
            this(hostUrl, jsonSerializer, httpMessageHandler, clientTimeout)
        {
            if (authenticationToken.Length > 0)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
        }

        public EducationProcessHttpFacade(RequestsJsonSerializer jsonSerializer, HttpClient httpClient)
        {
            _httpClient = httpClient;
            Setup(jsonSerializer);
        }

        private void Setup(RequestsJsonSerializer jsonSerializer)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            _requestor = new EducationProcessApiRequestor(_httpClient, jsonSerializer);
        }

        public Task<T> Get<T>(string uri) =>
            _requestor.Get<T>(uri);

        public Task<T> Post<T>(string uri, object data = null) where T : class =>
            _requestor.Post<T>(uri, data);

        public Task Post(string uri, object data = null) =>
            _requestor.Post(uri, data);

        public Task<T> Put<T>(string uri, object data) =>
            _requestor.Put<T>(uri, data);

        public Task Put(string uri, object data) =>
            _requestor.Put(uri, data);

        public Task Delete(string uri) =>
            _requestor.Delete(uri);

        public Task Delete(string uri, object data) =>
            _requestor.Delete(uri, data);

        public async Task<AccessTokenResponse> LoginAsync(AccessTokenRequest accessTokenRequest)
        {
            string url = $"{_httpClient.BaseAddress.GetLeftPart(UriPartial.Authority)}/oauth/token";
            var accessTokenResponse = await _requestor.Post<AccessTokenResponse>(url, accessTokenRequest);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenResponse.AccessToken);

            return accessTokenResponse;
        }
    }
}