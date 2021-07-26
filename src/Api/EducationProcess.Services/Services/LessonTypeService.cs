using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class LessonTypeService : ILessonTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}