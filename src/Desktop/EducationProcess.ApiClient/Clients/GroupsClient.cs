using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Groups.Requests;
using EducationProcess.ApiClient.Models.Groups.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class GroupsClient : IGroupsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal GroupsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Group> GetGroupAsync(int groupId) =>
            await _httpFacade.Get<Group>($"Groups/{groupId}");

        public async Task<Group[]> GetAllGroupsAsync() =>
            await _httpFacade.Get<Group[]>($"Groups/array");


        public async Task<Group> CreateGroupAsync(GroupRequest group) =>
            await _httpFacade.Post<Group>($"Groups", group);

        public async Task<Group[]> CreateGroupArrayAsync(GroupRequest[] groups) =>
            await _httpFacade.Post<Group[]>($"Groups", groups);


        public async Task<Group> UpdateGroupAsync(GroupRequest group) =>
            await _httpFacade.Put<Group>($"Groups", group);

        public async Task<Group[]> UpdateGroupArrayAsync(GroupRequest[] groups) =>
            await _httpFacade.Put<Group[]>($"Groups", groups);


        public async Task DeleteGroupAsync(GroupRequest group) =>
            await _httpFacade.Delete($"Groups", group);

        public async Task DeleteGroupArrayAsync(GroupRequest[] groups) =>
            await _httpFacade.Delete($"Groups", groups);
    }
}