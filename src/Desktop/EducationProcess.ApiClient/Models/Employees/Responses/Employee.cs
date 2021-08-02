using System;

namespace EducationProcess.ApiClient.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int PostId { get; set; }
        public Guid? Rowguid { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public Post Post { get; set; }
    }
}