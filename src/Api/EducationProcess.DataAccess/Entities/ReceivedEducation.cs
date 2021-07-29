using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class ReceivedEducation
    {
        public ReceivedEducation()
        {
            Groups = new HashSet<Group>();
        }

        public int ReceivedEducationId { get; set; }
        public int ReceivedSpecialtyId { get; set; }
        public int ReceivedEducationFormId { get; set; }
        public int EducationLevelId { get; set; }
        public short StudyPeriodMonths { get; set; }
        public bool IsBudget { get; set; }

        public virtual EducationLevel EducationLevel { get; set; }
        public virtual ReceivedEducationForm ReceivedEducationForm { get; set; }
        public virtual ReceivedSpecialty ReceivedSpecialty { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}