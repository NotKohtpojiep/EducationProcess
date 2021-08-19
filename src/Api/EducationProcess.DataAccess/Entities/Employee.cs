using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Audiences = new HashSet<Audience>();
            EmployeeCathedras = new HashSet<EmployeeCathedra>();
            FixedDisciplineEmployeeFixers = new HashSet<FixedDiscipline>();
            FixedDisciplineFixingEmployees = new HashSet<FixedDiscipline>();
            Groups = new HashSet<Group>();
            ScheduleDisciplineCreatedByEmployees = new HashSet<ScheduleDiscipline>();
            ScheduleDisciplineModifiedByEmployees = new HashSet<ScheduleDiscipline>();
            ScheduleDisciplineReplacementCreatedByEmployees = new HashSet<ScheduleDisciplineReplacement>();
            ScheduleDisciplineReplacementModifiedByEmployees = new HashSet<ScheduleDisciplineReplacement>();
        }

        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int PostId { get; set; }
        public Guid? Rowguid { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Audience> Audiences { get; set; }
        public virtual ICollection<EmployeeCathedra> EmployeeCathedras { get; set; }
        public virtual ICollection<FixedDiscipline> FixedDisciplineEmployeeFixers { get; set; }
        public virtual ICollection<FixedDiscipline> FixedDisciplineFixingEmployees { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplineCreatedByEmployees { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplineModifiedByEmployees { get; set; }
        public virtual ICollection<ScheduleDisciplineReplacement> ScheduleDisciplineReplacementCreatedByEmployees { get; set; }
        public virtual ICollection<ScheduleDisciplineReplacement> ScheduleDisciplineReplacementModifiedByEmployees { get; set; }
    }
}