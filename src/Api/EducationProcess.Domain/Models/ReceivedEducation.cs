namespace EducationProcess.Domain.Models
{
    public class ReceivedEducation
    {
        public uint ReceivedEducationId { get; set; }
        public uint ReceivedSpecialtyId { get; set; }
        public uint ReceivedEducationFormId { get; set; }
        public uint EducationLevelId { get; set; }
        public ushort StudyPeriodMonths { get; set; }
        public bool IsBudget { get; set; }

        public EducationLevel EducationLevel { get; set; }
        public ReceivedEducationForm ReceivedEducationForm { get; set; }
        public ReceivedSpecialty ReceivedSpecialty { get; set; }
    }
}