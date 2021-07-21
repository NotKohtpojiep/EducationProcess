using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class Group
    {

        public int GroupId { get; set; }
        public string Name { get; set; }
        public byte CourseNumber { get; set; }
        public int CuratorId { get; set; }
        public int ReceivedEducationId { get; set; }
        public int? EducationPlanId { get; set; }
        public short ReceiptYear { get; set; }

        public  Employee Curator { get; set; }
        public  EducationPlan EducationPlan { get; set; }
        public  ReceivedEducation ReceivedEducation { get; set; }
        public List<FixedDiscipline> FixedDisciplines { get; set; }
    }
}
