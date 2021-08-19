using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public class SemesterDisciplineService : ISemesterDisciplineService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public SemesterDisciplineService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<SemesterDiscipline[]> GetAllSemesterDisciplines()
        {
            return await _educationProcessClient.SemesterDisciplines.GetAllSemesterDisciplinesAsync();
        }

        public async Task<SemesterDiscipline> CreateSemesterDiscipline(SemesterDiscipline semesterDiscipline)
        {
            throw new System.NotImplementedException();
        }
    }
}
