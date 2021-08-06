using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Cathedras.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class CathedrasClient : ICathedrasClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal CathedrasClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Cathedra> GetCathedraAsync(int cathedraId) =>
            await _httpFacade.Get<Cathedra>($"Cathedras/{cathedraId}");

        public async Task<Cathedra[]> GetAllCathedrasAsync() =>
            await _httpFacade.Get<Cathedra[]>($"Cathedras/array");
    }
}