using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ScheduleDisciplineService : IScheduleDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleDisciplineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}