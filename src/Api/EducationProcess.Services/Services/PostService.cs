using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            DataAccess.Entities.Post post =
                await _unitOfWork.Posts.GetFirstWhereAsync(x => x.PostId == postId);
            return _mapper.Map<DataAccess.Entities.Post, Post>(post);
        }

        public async Task<Post[]> GetAllPostsAsync()
        {
            DataAccess.Entities.Post[] post =
                await _unitOfWork.Posts.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Post[], Post[]>(post);
        }

        public async Task<Post> AddPostAsync(Post newPost)
        {
            DataAccess.Entities.Post post =
                _mapper.Map<Post, DataAccess.Entities.Post>(newPost);

            post = await _unitOfWork.Posts.AddAsync(post);
            return _mapper.Map<DataAccess.Entities.Post, Post>(post);
        }

        public async Task<Post[]> AddRangePostAsync(Post[] newPosts)
        {
            DataAccess.Entities.Post[] posts =
                _mapper.Map<Post[], DataAccess.Entities.Post[]>(newPosts);

            posts = await _unitOfWork.Posts.AddRangeAsync(posts);
            return _mapper.Map<DataAccess.Entities.Post[], Post[]>(posts);
        }

        public async Task<Post> UpdatePostAsync(Post newPost)
        {
            DataAccess.Entities.Post post =
                _mapper.Map<Post, DataAccess.Entities.Post>(newPost);

            post = await _unitOfWork.Posts.UpdateAsync(post);
            return _mapper.Map<DataAccess.Entities.Post, Post>(post);
        }

        public async Task<Post[]> UpdateRangePostAsync(Post[] newPost)
        {
            DataAccess.Entities.Post[] post =
                _mapper.Map<Post[], DataAccess.Entities.Post[]>(newPost);

            post = await _unitOfWork.Posts.UpdateRangeAsync(post);
            return _mapper.Map<DataAccess.Entities.Post[], Post[]>(post);
        }

        public async Task DeletePostAsync(Post post)
        {
            DataAccess.Entities.Post mappedPost =
                _mapper.Map<Post, DataAccess.Entities.Post>(post);

            await _unitOfWork.Posts.DeleteAsync(mappedPost);
        }

        public async Task DeleteRangePostAsync(Post[] posts)
        {
            DataAccess.Entities.Post[] mappedPosts =
                _mapper.Map<Post[], DataAccess.Entities.Post[]>(posts);

            await _unitOfWork.Posts.DeleteRangeAsync(mappedPosts);
        }
    }
}