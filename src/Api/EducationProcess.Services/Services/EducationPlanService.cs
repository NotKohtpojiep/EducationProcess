using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationPlanService : IEducationPlanService
    {
        private readonly IEducationPlanService _educationPlanService;

        public EducationPlanService(IEducationPlanService educationPlanService)
        {
            _educationPlanService = educationPlanService;
        }
    }
}