using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class CathedraSpecialtyService : ICathedraSpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CathedraSpecialtyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}