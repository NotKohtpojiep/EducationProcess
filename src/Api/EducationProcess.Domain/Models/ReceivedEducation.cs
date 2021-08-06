namespace EducationProcess.Domain.Models
{
    public class ReceivedEducation
    {
        public int ReceivedEducationId { get; set; }
        public int ReceivedSpecialtyId { get; set; }
        public int ReceivedEducationFormId { get; set; }
        public int EducationLevelId { get; set; }
        public short StudyPeriodMonths { get; set; }
        public bool IsBudget { get; set; }

        public EducationLevel EducationLevel { get; set; }
        public ReceivedEducationForm ReceivedEducationForm { get; set; }
        public ReceivedSpecialty ReceivedSpecialty { get; set; }
    }
}