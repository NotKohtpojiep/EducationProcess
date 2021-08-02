using System.Collections.Generic;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Internal.Http;

namespace EducationProcess.ApiClient
{
    public sealed class ConnectionClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal ConnectionClient(
            EducationProcessHttpFacade httpFacade
        )
        {
            _httpFacade = httpFacade;
        }

        public Task<T> GetAsync<T>(string uri)
            => _httpFacade.Get<T>(uri);

        public Task<IList<T>> GetPagedListAsync<T>(string uri)
            => _httpFacade.GetPagedList<T>(uri);
    }
}