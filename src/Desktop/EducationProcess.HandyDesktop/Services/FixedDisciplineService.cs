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

        public async Task<FixedDiscipline[]> GetAllAsync()
        {
            return await _educationProcessClient.FixedDisciplines.GetAllWithIncludeAsync();
        }

        public async Task<FixedDiscipline[]> GetPrettyRangeAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _educationProcessClient.FixedDisciplines.GetAllWithIncludeAsync(pageNumber, pageSize);
        }

        public async Task<FixedDiscipline[]> GetAllByTeacherIdAsync(int teacherId)
        {
            return await _educationProcessClient.FixedDisciplines.GetAllByTeacherIdWithIncludeAsync(teacherId);
        }

        public async Task<FixedDiscipline[]> GetAllByGroupIdAsync(int groupId)
        {
            return await _educationProcessClient.FixedDisciplines.GetAllByGroupIdWithIncludeAsync(groupId);
        }

        public async Task<int> GetCount()
        {
            return await _educationProcessClient.FixedDisciplines.GetCount();
        }

        public async Task<FixedDiscipline> CreateAsync(FixedDiscipline fixedDiscipline)
        {
            return await _educationProcessClient.FixedDisciplines.CreateAsync(ConvertToFixedDisciplineRequest(fixedDiscipline));
        }

        public async Task<FixedDiscipline[]> CreateArrayAsync(FixedDiscipline[] fixedDisciplines)
        {
            FixedDisciplineRequest[] fixedDisciplineRequests =
                fixedDisciplines.Select(ConvertToFixedDisciplineRequest).ToArray();
            return await _educationProcessClient.FixedDisciplines.CreateArrayAsync(fixedDisciplineRequests);
        }

        public async Task<FixedDiscipline> UpdateAsync(FixedDiscipline fixedDiscipline)
        {
            return await _educationProcessClient.FixedDisciplines.UpdateAsync(ConvertToFixedDisciplineRequest(fixedDiscipline));
        }

        public async Task<FixedDiscipline[]> UpdateArray(FixedDiscipline[] fixedDisciplines)
        {
            FixedDisciplineRequest[] fixedDisciplineRequests =
                fixedDisciplines.Select(ConvertToFixedDisciplineRequest).ToArray();
            return await _educationProcessClient.FixedDisciplines.UpdateArrayAsync(fixedDisciplineRequests);
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
