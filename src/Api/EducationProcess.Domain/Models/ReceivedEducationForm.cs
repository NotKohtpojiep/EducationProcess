namespace EducationProcess.Domain.Models
{
    public class ReceivedEducationForm
    {
        public int ReceivedEducationFormId { get; set; }
        public int EducationFormId { get; set; }
        public string AdditionalInfo { get; set; }

        public EducationForm EducationForm { get; set; }
    }
}