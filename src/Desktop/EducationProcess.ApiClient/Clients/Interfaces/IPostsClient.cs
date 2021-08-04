using System.Threading.Tasks;
using EducationProcess.ApiClient.Models;
using EducationProcess.ApiClient.Models.Employees.Requests;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IPostsClient
    {
        Task<Post> GetPostAsync(int postId);
        Task<Post[]> GetAllPostsAsync();

        Task<Post> CreatePostAsync(PostRequest post);
        Task<Post[]> CreatePostArrayAsync(PostRequest[] posts);

        Task<Post> UpdatePostAsync(PostRequest post);
        Task<Post[]> UpdatePostArrayAsync(PostRequest[] posts);


        Task DeletePostAsync(PostRequest post);
        Task DeletePostArrayAsync(PostRequest[] posts);
    }
}