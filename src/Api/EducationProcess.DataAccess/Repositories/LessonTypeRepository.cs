using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class LessonTypeRepository : RepositoryBase<LessonType>, ILessonTypeRepository
    {
        private readonly EducationProcessContext _context;
        
        public LessonTypeRepository(EducationProcessContext context) : base(context)
        {
            _context = context;
        }
    }
}