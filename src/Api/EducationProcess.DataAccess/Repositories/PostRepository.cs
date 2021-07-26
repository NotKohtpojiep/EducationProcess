using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private readonly EducationProcessContext _context;
        
        public PostRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}