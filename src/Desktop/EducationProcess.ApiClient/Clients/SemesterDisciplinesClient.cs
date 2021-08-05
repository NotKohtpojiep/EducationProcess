using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Requests;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class SemesterDisciplinesClient : ISemesterDisciplinesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal SemesterDisciplinesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<SemesterDiscipline> GetSemesterDisciplineAsync(int semesterDisciplineId) =>
            await _httpFacade.Get<SemesterDiscipline>($"SemesterDisciplines/{semesterDisciplineId}");

        public async Task<SemesterDiscipline[]> GetAllSemesterDisciplinesAsync() =>
            await _httpFacade.Get<SemesterDiscipline[]>($"SemesterDisciplines/array");


        public async Task<SemesterDiscipline> CreateSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline) =>
            await _httpFacade.Post<SemesterDiscipline>($"SemesterDisciplines", semesterDiscipline);

        public async Task<SemesterDiscipline[]> CreateSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines) =>
            await _httpFacade.Post<SemesterDiscipline[]>($"SemesterDisciplines", semesterDisciplines);


        public async Task<SemesterDiscipline> UpdateSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline) =>
            await _httpFacade.Put<SemesterDiscipline>($"SemesterDisciplines", semesterDiscipline);

        public async Task<SemesterDiscipline[]> UpdateSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines) =>
            await _httpFacade.Put<SemesterDiscipline[]>($"SemesterDisciplines", semesterDisciplines);


        public async Task DeleteSemesterDisciplineAsync(SemesterDisciplineRequest semesterDiscipline) =>
            await _httpFacade.Delete($"SemesterDisciplines", semesterDiscipline);

        public async Task DeleteSemesterDisciplineArrayAsync(SemesterDisciplineRequest[] semesterDisciplines) =>
            await _httpFacade.Delete($"SemesterDisciplines", semesterDisciplines);
    }
}