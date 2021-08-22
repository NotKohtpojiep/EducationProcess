using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.FixedDisciplines.Requests;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class FixedDisciplinesClient : IFixedDisciplinesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal FixedDisciplinesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<FixedDiscipline> GetFixedDisciplineAsync(int fixedDisciplineId) =>
            await _httpFacade.Get<FixedDiscipline>($"FixedDisciplines/{fixedDisciplineId}");

        public async Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync() =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/array");

        public async Task<FixedDiscipline[]> GetAllFixedDisciplinesWithIncludeAsync() =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/array/with-include");

        public async Task<FixedDiscipline[]> GetAllFixedDisciplinesByTeacherIdWithIncludeAsync(int teacherId) =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/for-teacher/{teacherId}");

        public async Task<FixedDiscipline> CreateFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Post<FixedDiscipline>($"FixedDisciplines", fixedDiscipline);

        public async Task<FixedDiscipline[]> CreateFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Post<FixedDiscipline[]>($"FixedDisciplines", fixedDisciplines);


        public async Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Put<FixedDiscipline>($"FixedDisciplines", fixedDiscipline);

        public async Task<FixedDiscipline[]> UpdateFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Put<FixedDiscipline[]>($"FixedDisciplines", fixedDisciplines);


        public async Task DeleteFixedDisciplineAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Delete($"FixedDisciplines", fixedDiscipline);

        public async Task DeleteFixedDisciplineArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Delete($"FixedDisciplines", fixedDisciplines);
    }
}