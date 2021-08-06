namespace EducationProcess.ApiClient.Models.Audiences.Requests
{
    public class AudienceRequest
    {
        public int AudienceId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? EmployeeHeadId { get; set; }
        public int? AudienceTypeId { get; set; }
        public short? SeatsCount { get; set; }
        public int DepartmentId { get; set; }
    }
}