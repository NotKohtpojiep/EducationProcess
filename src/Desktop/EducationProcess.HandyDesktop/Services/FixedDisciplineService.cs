using System.Linq;
using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.FixedDisciplines.Requests;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public class FixedDisciplineService : IFixedDisciplineService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public FixedDisciplineService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync()
        {
            return await _educationProcessClient.FixedDisciplines.GetAllFixedDisciplinesWithIncludeAsync();
        }

        public async Task<FixedDiscipline> CreateFixedDisciplineAsync(FixedDiscipline fixedDiscipline)
        {

            return await _educationProcessClient.FixedDisciplines.CreateFixedDisciplineAsync(ConvertToFixedDisciplineRequest(fixedDiscipline));
        }

        public async Task<FixedDiscipline[]> CreateFixedDisciplineArrayAsync(FixedDiscipline[] fixedDisciplines)
        {
            FixedDisciplineRequest[] fixedDisciplineRequests =
                fixedDisciplines.Select(ConvertToFixedDisciplineRequest).ToArray();
            return await _educationProcessClient.FixedDisciplines.CreateFixedDisciplineArrayAsync(fixedDisciplineRequests);
        }

        public async Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDiscipline fixedDiscipline)
        {
            return await _educationProcessClient.FixedDisciplines.UpdateFixedDisciplineAsync(ConvertToFixedDisciplineRequest(fixedDiscipline));
        }

        public async Task<FixedDiscipline[]> UpdateFixedDisciplineArray(FixedDiscipline[] fixedDisciplines)
        {
            FixedDisciplineRequest[] fixedDisciplineRequests =
                fixedDisciplines.Select(ConvertToFixedDisciplineRequest).ToArray();
            return await _educationProcessClient.FixedDisciplines.UpdateFixedDisciplineArrayAsync(fixedDisciplineRequests);
        }

        private FixedDisciplineRequest ConvertToFixedDisciplineRequest(FixedDiscipline fixedDiscipline)
        {
            return new FixedDisciplineRequest
            {
                FixedDisciplineId = fixedDiscipline.FixedDisciplineId,
                FixingEmployeeId = fixedDiscipline.FixingEmployeeId,
                SemesterDisciplineId = fixedDiscipline.SemesterDisciplineId,
                GroupId = fixedDiscipline.GroupId,
                IsAgreed = fixedDiscipline.IsAgreed,
                IsWatched = fixedDiscipline.IsWatched,
                EmployeeFixerId = fixedDiscipline.EmployeeFixerId,
                CommentByFixingEmployee = fixedDiscipline.CommentByFixingEmployee,
                CommentByEmployeeFixer = fixedDiscipline.CommentByEmployeeFixer
            };
        }
    }
}
