using System;

namespace EducationProcess.Domain.Models
{
    public class Employee
    {
        public uint EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public uint PostId { get; set; }
        public Guid? Rowguid { get; set; }

        public Post Post { get; set; }
    }
}