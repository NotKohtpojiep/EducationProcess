using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Audience
    {
        public Audience()
        {
            ScheduleDisciplineReplacements = new HashSet<ScheduleDisciplineReplacement>();
            ScheduleDisciplines = new HashSet<ScheduleDiscipline>();
        }

        public int AudienceId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? EmployeeHeadId { get; set; }
        public int? AudienceTypeId { get; set; }
        public short? SeatsCount { get; set; }

        public virtual AudienceType AudienceType { get; set; }
        public virtual Employee EmployeeHead { get; set; }
        public virtual ICollection<ScheduleDisciplineReplacement> ScheduleDisciplineReplacements { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
