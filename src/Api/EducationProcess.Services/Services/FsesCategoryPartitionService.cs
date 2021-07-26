using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FsesCategoryPartitionService : IFsesCategoryPartitionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FsesCategoryPartitionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}