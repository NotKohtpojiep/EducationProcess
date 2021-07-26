using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationPlanSemesterDisciplineService : IEducationPlanSemesterDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationPlanSemesterDisciplineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}