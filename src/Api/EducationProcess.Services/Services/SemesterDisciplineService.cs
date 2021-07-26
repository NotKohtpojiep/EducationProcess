using EducationProcess.DataAccess;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class SemesterDisciplineService : ISemesterDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterDisciplineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}