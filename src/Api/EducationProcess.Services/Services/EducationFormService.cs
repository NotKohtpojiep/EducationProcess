using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationFormService : IEducationFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationFormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}