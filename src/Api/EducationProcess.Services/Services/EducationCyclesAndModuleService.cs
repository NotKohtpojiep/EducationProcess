using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationCyclesAndModuleService : IEducationCyclesAndModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationCyclesAndModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}