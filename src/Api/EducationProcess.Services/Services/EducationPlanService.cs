using EducationProcess.DataAccess.Repositories.Interfaces;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationPlanService : IEducationPlanService
    {
        private readonly IEducationPlanRepository _educationPlanRepository;

        public EducationPlanService(IEducationPlanRepository educationPlanRepository)
        {
            _educationPlanRepository = educationPlanRepository;
        }
    }
}