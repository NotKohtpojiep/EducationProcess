namespace EducationProcess.Domain.Models
{
    public class ReceivedEducationForm
    {
        public uint ReceivedEducationFormId { get; set; }
        public uint EducationFormId { get; set; }
        public string AdditionalInfo { get; set; }

        public EducationForm EducationForm { get; set; }
    }
}