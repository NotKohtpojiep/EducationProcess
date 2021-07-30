using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Group> GetGroupByIdAsync(int groupId);
        Task<Group[]> GetAllGroupsAsync();
        Task<Group> AddGroupAsync(Group newGroup);
        Task<Group[]> AddRangeGroupAsync(Group[] newGroups);
        Task<Group> UpdateGroupAsync(Group newGroup);
        Task<Group[]> UpdateRangeGroupAsync(Group[] newGroup);
        Task DeleteGroupAsync(Group group);
        Task DeleteRangeGroupAsync(Group[] groups);
    }
}