using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Groups.Requests;
using EducationProcess.ApiClient.Models.Groups.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IGroupsClient
    {
        Task<Group> GetGroupAsync(int groupId);
        Task<Group[]> GetAllGroupsAsync();

        Task<Group> CreateGroupAsync(GroupRequest group);
        Task<Group[]> CreateGroupArrayAsync(GroupRequest[] groups);

        Task<Group> UpdateGroupAsync(GroupRequest group);
        Task<Group[]> UpdateGroupArrayAsync(GroupRequest[] groups);

        Task DeleteGroupAsync(GroupRequest group);
        Task DeleteGroupArrayAsync(GroupRequest[] groups);
    }
}