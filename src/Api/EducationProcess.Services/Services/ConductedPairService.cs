using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ConductedPairService : IConductedPairService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConductedPairService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}