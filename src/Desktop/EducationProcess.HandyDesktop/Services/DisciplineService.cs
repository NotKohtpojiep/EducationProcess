using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.Disciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public DisciplineService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<Discipline[]> GetAllDisciplines()
        {
            return await _educationProcessClient.Disciplines.GetAllDisciplinesWithIncludeAsync();
        }

        public Task<Discipline> CreateDiscipline(Discipline discipline)
        {
            throw new System.NotImplementedException();
        }
    }
}
