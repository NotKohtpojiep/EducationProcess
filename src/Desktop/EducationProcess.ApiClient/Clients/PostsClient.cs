using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Employees.Requests;
using EducationProcess.ApiClient.Models.Employees.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class PostsClient : IPostsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal PostsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Post> GetPostAsync(int postId) =>
            await _httpFacade.Get<Post>($"Posts/{postId}");

        public async Task<Post[]> GetAllPostsAsync() =>
            await _httpFacade.Get<Post[]>($"Posts/array");


        public async Task<Post> CreatePostAsync(PostRequest post) =>
            await _httpFacade.Post<Post>($"Posts", post);

        public async Task<Post[]> CreatePostArrayAsync(PostRequest[] posts) =>
            await _httpFacade.Post<Post[]>($"Posts", posts);


        public async Task<Post> UpdatePostAsync(PostRequest post) =>
            await _httpFacade.Put<Post>($"Posts", post);

        public async Task<Post[]> UpdatePostArrayAsync(PostRequest[] posts) =>
            await _httpFacade.Put<Post[]>($"Posts", posts);


        public async Task DeletePostAsync(PostRequest post) =>
            await _httpFacade.Delete($"Posts", post);

        public async Task DeletePostArrayAsync(PostRequest[] posts) =>
            await _httpFacade.Delete($"Posts", posts);
    }
}