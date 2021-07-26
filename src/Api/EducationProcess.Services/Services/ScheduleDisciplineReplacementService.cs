using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ScheduleDisciplineReplacementService : IScheduleDisciplineReplacementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleDisciplineReplacementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}