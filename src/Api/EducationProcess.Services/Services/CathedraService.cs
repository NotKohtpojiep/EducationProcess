using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class CathedraService : ICathedraService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CathedraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}