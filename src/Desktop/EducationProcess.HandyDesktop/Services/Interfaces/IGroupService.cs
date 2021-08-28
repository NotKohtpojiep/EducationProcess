using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Groups.Responses;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IGroupService
    {
        Task<Group[]> GetAllGroups();
        Task<Group[]> GetAllCurrentGroupsByDate(DateTime date);
        Task<Group> CreateGroup(Group group);
    }
}
