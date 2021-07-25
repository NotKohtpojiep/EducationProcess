namespace EducationProcess.Domain.Models
{
    public class EducationPlanSemesterDiscipline
    {
        public uint EducationPlanId { get; set; }
        public uint SemesterDisciplineId { get; set; }

        public EducationPlan EducationPlan { get; set; }
        public SemesterDiscipline SemesterDiscipline { get; set; }
    }
}