using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedEducationFormService : IReceivedEducationFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceivedEducationFormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}