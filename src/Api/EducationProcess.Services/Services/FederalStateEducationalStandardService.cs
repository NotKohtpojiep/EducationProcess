using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FederalStateEducationalStandardService : IFederalStateEducationalStandardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FederalStateEducationalStandardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}