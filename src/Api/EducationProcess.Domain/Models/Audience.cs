namespace EducationProcess.Domain.Models
{
    public class Audience
    {
        public int AudienceId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? EmployeeHeadId { get; set; }
        public int? AudienceTypeId { get; set; }
        public short? SeatsCount { get; set; }
        public int DepartmentId { get; set; }

        public AudienceType AudienceType { get; set; }
        public Department Department { get; set; }
        public Employee EmployeeHead { get; set; }
    }
}