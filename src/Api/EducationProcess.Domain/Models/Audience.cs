namespace EducationProcess.Domain.Models
{
    public class Audience
    {
        public uint AudienceId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public uint? EmployeeHeadId { get; set; }
        public uint? AudienceTypeId { get; set; }
        public ushort? SeatsCount { get; set; }

        public AudienceType AudienceType { get; set; }
        public Employee EmployeeHead { get; set; }
    }
}