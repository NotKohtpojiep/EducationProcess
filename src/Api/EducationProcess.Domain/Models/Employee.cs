using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class Employee
    {

        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int PostId { get; set; }
        public Guid? Rowguid { get; set; }

        public virtual Post Post { get; set; }
        public List<Audience> Audiences { get; set; }
        public List<EmployeeCathedra> EmployeeCathedras { get; set; }
        public List<FixedDiscipline> FixedDisciplineFixerEmployees { get; set; }
        public List<FixedDiscipline> FixedDisciplineFixingEmployees { get; set; }
        public List<Group> Groups { get; set; }
        public List<ScheduleDiscipline> ScheduleDisciplineCreatedByEmployees { get; set; }
        public List<ScheduleDiscipline> ScheduleDisciplineModifiedByEmployees { get; set; }
        public List<ScheduleDisciplineReplacement> ScheduleDisciplineReplacementCreatedByEmployees { get; set; }
        public List<ScheduleDisciplineReplacement> ScheduleDisciplineReplacementModifiedByEmployees { get; set; }
    }
}
