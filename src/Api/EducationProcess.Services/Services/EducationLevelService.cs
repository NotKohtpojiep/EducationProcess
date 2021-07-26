using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationLevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}