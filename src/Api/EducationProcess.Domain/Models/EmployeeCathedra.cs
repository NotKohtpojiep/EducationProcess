namespace EducationProcess.Domain.Models
{
    public class EmployeeCathedra
    {
        public uint EmployeeId { get; set; }
        public uint CathedraId { get; set; }

        public Cathedra Cathedra { get; set; }
        public Employee Employee { get; set; }
    }
}