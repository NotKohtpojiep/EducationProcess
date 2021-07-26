using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedEducationService : IReceivedEducationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceivedEducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}