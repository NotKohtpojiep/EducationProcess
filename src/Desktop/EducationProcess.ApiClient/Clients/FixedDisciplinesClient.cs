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

        public async Task<FixedDiscipline> GetAsync(int fixedDisciplineId) =>
            await _httpFacade.Get<FixedDiscipline>($"FixedDisciplines/{fixedDisciplineId}");

        public async Task<FixedDiscipline[]> GetAllAsync() =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines");

        public async Task<FixedDiscipline[]> GetAllWithIncludeAsync(int pageNumber = 1, int pageSize = 10) =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/pretty?PageNumber={pageNumber}&PageSize={pageSize}");

        public async Task<FixedDiscipline[]> GetAllByTeacherIdWithIncludeAsync(int teacherId) =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/pretty/teacher/{teacherId}");

        public async Task<FixedDiscipline[]> GetAllByGroupIdWithIncludeAsync(int groupId) =>
            await _httpFacade.Get<FixedDiscipline[]>($"FixedDisciplines/pretty/group/{groupId}");

        public async Task<int> GetCount() =>
            await _httpFacade.Get<int>($"FixedDisciplines/count");


        public async Task<FixedDiscipline> CreateAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Post<FixedDiscipline>($"FixedDisciplines/{fixedDiscipline.FixedDisciplineId}", fixedDiscipline);

        public async Task<FixedDiscipline[]> CreateArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Post<FixedDiscipline[]>($"FixedDisciplines", fixedDisciplines);


        public async Task<FixedDiscipline> UpdateAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Put<FixedDiscipline>($"FixedDisciplines/{fixedDiscipline.FixedDisciplineId}", fixedDiscipline);

        public async Task<FixedDiscipline[]> UpdateArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Put<FixedDiscipline[]>($"FixedDisciplines", fixedDisciplines);


        public async Task DeleteAsync(FixedDisciplineRequest fixedDiscipline) =>
            await _httpFacade.Delete($"FixedDisciplines/{fixedDiscipline.FixedDisciplineId}", fixedDiscipline);

        public async Task DeleteArrayAsync(FixedDisciplineRequest[] fixedDisciplines) =>
            await _httpFacade.Delete($"FixedDisciplines", fixedDisciplines);
    }
}