using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class AudienceTypeService : IAudienceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AudienceTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}