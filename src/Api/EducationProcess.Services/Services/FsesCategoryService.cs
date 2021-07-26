using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FsesCategoryService : IFsesCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FsesCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}