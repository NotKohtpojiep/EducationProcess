namespace EducationProcess.Domain.Models
{
    public class EducationPlanSemesterDiscipline
    {
        public int EducationPlanId { get; set; }
        public int SemesterDisciplineId { get; set; }

        public EducationPlan EducationPlan { get; set; }
        public SemesterDiscipline SemesterDiscipline { get; set; }
    }
}