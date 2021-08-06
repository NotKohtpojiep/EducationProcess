using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class ReceivedEducationForm
    {
        public ReceivedEducationForm()
        {
            ReceivedEducations = new HashSet<ReceivedEducation>();
        }

        public int ReceivedEducationFormId { get; set; }
        public int EducationFormId { get; set; }
        public string AdditionalInfo { get; set; }

        public virtual EducationForm EducationForm { get; set; }
        public virtual ICollection<ReceivedEducation> ReceivedEducations { get; set; }
    }
}