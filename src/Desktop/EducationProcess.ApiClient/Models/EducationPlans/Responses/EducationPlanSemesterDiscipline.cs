using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.ApiClient.Models
{
    public class EducationPlanSemesterDiscipline
    {
        public int EducationPlanId { get; set; }
        public int SemesterDisciplineId { get; set; }

        public EducationPlan EducationPlan { get; set; }
        public SemesterDiscipline SemesterDiscipline { get; set; }
    }
}