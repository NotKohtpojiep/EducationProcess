using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetPostByIdAsync(int postId);
        Task<Post[]> GetAllPostsAsync();
        Task<Post> AddPostAsync(Post newPost);
        Task<Post[]> AddRangePostAsync(Post[] newPosts);
        Task<Post> UpdatePostAsync(Post newPost);
        Task<Post[]> UpdateRangePostAsync(Post[] newPost);
        Task DeletePostAsync(Post post);
        Task DeleteRangePostAsync(Post[] posts);
    }
}