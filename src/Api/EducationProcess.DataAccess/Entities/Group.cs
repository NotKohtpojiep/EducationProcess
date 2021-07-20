using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Group
    {
        public Group()
        {
            FixedDisciplines = new HashSet<FixedDiscipline>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public byte CourseNumber { get; set; }
        public int CuratorId { get; set; }
        public int ReceivedEducationId { get; set; }
        public int? EducationPlanId { get; set; }
        public short ReceiptYear { get; set; }

        public virtual Employee Curator { get; set; }
        public virtual EducationPlan EducationPlan { get; set; }
        public virtual ReceivedEducation ReceivedEducation { get; set; }
        public virtual ICollection<FixedDiscipline> FixedDisciplines { get; set; }
    }
}
