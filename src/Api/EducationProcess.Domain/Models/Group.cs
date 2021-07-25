namespace EducationProcess.Domain.Models
{
    public class Group
    {
        public uint GroupId { get; set; }
        public string Name { get; set; }
        public byte CourseNumber { get; set; }
        public uint CuratorId { get; set; }
        public uint ReceivedEducationId { get; set; }
        public uint? EducationPlanId { get; set; }
        public ushort ReceiptYear { get; set; }

        public Employee Curator { get; set; }
        public EducationPlan EducationPlan { get; set; }
        public ReceivedEducation ReceivedEducation { get; set; }
    }
}