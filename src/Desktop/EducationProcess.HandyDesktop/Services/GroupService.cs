using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.Groups.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public class GroupService : IGroupService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public GroupService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<Group[]> GetAllGroups()
        {
            return await _educationProcessClient.Groups.GetAllGroupsAsync();
        }

        public async Task<Group[]> GetAllCurrentGroupsByDate(DateTime date)
        {
            return await _educationProcessClient.Groups.GetAllCurrentGroupsByDateAsync(date);
        }

        public async Task<Group> CreateGroup(Group @group)
        {
            throw new NotImplementedException();
        }
    }
}
