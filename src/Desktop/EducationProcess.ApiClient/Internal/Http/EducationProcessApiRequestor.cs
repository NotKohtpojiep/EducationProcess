using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Internal.Http.Serialization;

namespace EducationProcess.ApiClient.Internal.Http
{
    internal sealed class EducationProcessApiRequestor
    {
        private readonly HttpClient _client;
        private readonly RequestsJsonSerializer _jsonSerializer;

        public EducationProcessApiRequestor(HttpClient client, RequestsJsonSerializer jsonSerializer)
        {
            _client = client;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<T> Get<T>(string url)
        {
            var responseMessage = await _client.GetAsync(url);
            await EnsureSuccessStatusCode(responseMessage);
            return await ReadResponse<T>(responseMessage);
        }

        public async Task<T> Post<T>(string url, object data = null)
        {
            StringContent content = SerializeToString(data);
            var responseMessage = await _client.PostAsync(url, content);
            await EnsureSuccessStatusCode(responseMessage);
            return await ReadResponse<T>(responseMessage);
        }

        public async Task Post(string url, object data = null)
        {
            StringContent content = SerializeToString(data);
            var responseMessage = await _client.PostAsync(url, content);
            await EnsureSuccessStatusCode(responseMessage);
        }

        public async Task<T> Put<T>(string url, object data)
        {
            StringContent content = SerializeToString(data);
            var responseMessage = await _client.PutAsync(url, content);
            await EnsureSuccessStatusCode(responseMessage);
            return await ReadResponse<T>(responseMessage);
        }

        public async Task Put(string url, object data)
        {
            StringContent content = SerializeToString(data);
            var responseMessage = await _client.PutAsync(url, content);
            await EnsureSuccessStatusCode(responseMessage);
        }

        public async Task Delete(string url)
        {
            var responseMessage = await _client.DeleteAsync(url);
            await EnsureSuccessStatusCode(responseMessage);
        }

        public async Task Delete(string url, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = SerializeToString(data)
            };
            var responseMessage = await _client.SendAsync(request);
            await EnsureSuccessStatusCode(responseMessage);
        }

        public async Task<Tuple<T, HttpResponseHeaders>> GetWithHeaders<T>(string url)
        {
            var responseMessage = await _client.GetAsync(url);
            await EnsureSuccessStatusCode(responseMessage);
            return Tuple.Create(await ReadResponse<T>(responseMessage), responseMessage.Headers);
        }

        private static async Task EnsureSuccessStatusCode(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
                return;

            string errorResponse = await responseMessage.Content.ReadAsStringAsync();
            throw new EducationProcessException(responseMessage.StatusCode, errorResponse ?? "");
        }

        private async Task<T> ReadResponse<T>(HttpResponseMessage responseMessage)
        {
            string response = await responseMessage.Content.ReadAsStringAsync();
            var result = _jsonSerializer.Deserialize<T>(response);
            return result;
        }

        private StringContent SerializeToString(object data)
        {
            string serializedObject = _jsonSerializer.Serialize(data);

            var content = data != null ?
                new StringContent(serializedObject) :
                new StringContent(string.Empty);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}