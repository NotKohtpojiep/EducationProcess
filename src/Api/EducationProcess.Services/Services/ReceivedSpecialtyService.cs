using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedSpecialtyService : IReceivedSpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceivedSpecialtyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}