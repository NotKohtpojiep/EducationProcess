using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class IntermediateCertificationFormService : IIntermediateCertificationFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IntermediateCertificationFormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}