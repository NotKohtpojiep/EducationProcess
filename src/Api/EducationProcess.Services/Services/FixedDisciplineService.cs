using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FixedDisciplineService : IFixedDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FixedDisciplineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}