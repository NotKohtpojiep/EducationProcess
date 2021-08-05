namespace EducationProcess.ApiClient.Models.Groups.Requests
{
    public class GroupRequest
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public byte CourseNumber { get; set; }
        public int CuratorId { get; set; }
        public int ReceivedEducationId { get; set; }
        public int? EducationPlanId { get; set; }
        public short ReceiptYear { get; set; }
        public int DepartmentId { get; set; }
    }
}