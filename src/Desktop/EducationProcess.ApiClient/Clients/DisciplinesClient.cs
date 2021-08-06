using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Disciplines.Requests;
using EducationProcess.ApiClient.Models.Disciplines.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class DisciplinesClient : IDisciplinesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal DisciplinesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Discipline> GetDisciplineAsync(int disciplineId) =>
            await _httpFacade.Get<Discipline>($"Disciplines/{disciplineId}");

        public async Task<Discipline[]> GetAllDisciplinesAsync() =>
            await _httpFacade.Get<Discipline[]>($"Disciplines/array");


        public async Task<Discipline> CreateDisciplineAsync(DisciplineRequest discipline) =>
            await _httpFacade.Post<Discipline>($"Disciplines", discipline);

        public async Task<Discipline[]> CreateDisciplineArrayAsync(DisciplineRequest[] disciplines) =>
            await _httpFacade.Post<Discipline[]>($"Disciplines", disciplines);


        public async Task<Discipline> UpdateDisciplineAsync(DisciplineRequest discipline) =>
            await _httpFacade.Put<Discipline>($"Disciplines", discipline);

        public async Task<Discipline[]> UpdateDisciplineArrayAsync(DisciplineRequest[] disciplines) =>
            await _httpFacade.Put<Discipline[]>($"Disciplines", disciplines);


        public async Task DeleteDisciplineAsync(DisciplineRequest discipline) =>
            await _httpFacade.Delete($"Disciplines", discipline);

        public async Task DeleteDisciplineArrayAsync(DisciplineRequest[] disciplines) =>
            await _httpFacade.Delete($"Disciplines", disciplines);
    }
}