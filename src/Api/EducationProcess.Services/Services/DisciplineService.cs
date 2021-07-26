using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisciplineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}