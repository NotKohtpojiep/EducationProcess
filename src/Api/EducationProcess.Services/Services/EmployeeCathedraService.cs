using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EmployeeCathedraService : IEmployeeCathedraService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeCathedraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}