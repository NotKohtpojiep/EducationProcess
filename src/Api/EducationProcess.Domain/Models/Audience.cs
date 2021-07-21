using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models
{
    public partial class Audience
    {

        public int AudienceId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? EmployeeHeadId { get; set; }
        public int? AudienceTypeId { get; set; }
        public short? SeatsCount { get; set; }

        public AudienceType AudienceType { get; set; }
        public Employee EmployeeHead { get; set; }
        public List<ScheduleDisciplineReplacement> ScheduleDisciplineReplacements { get; set; }
        public List<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
