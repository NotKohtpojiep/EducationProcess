using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.ApiClient.Models.ReceivedEducations.Responses;

namespace EducationProcess.ApiClient.Models.Groups.Responses
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public byte CourseNumber { get; set; }
        public int CuratorId { get; set; }
        public int ReceivedEducationId { get; set; }
        public int? EducationPlanId { get; set; }
        public short ReceiptYear { get; set; }
        public int DepartmentId { get; set; }

        public Employee Curator { get; set; }
        public Department Department { get; set; }
        public EducationPlan EducationPlan { get; set; }
        public ReceivedEducation ReceivedEducation { get; set; }
    }
}