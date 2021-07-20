using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class ScheduleDiscipline
    {
        public ScheduleDiscipline()
        {
            ConductedPairs = new HashSet<ConductedPair>();
            ScheduleDisciplineReplacements = new HashSet<ScheduleDisciplineReplacement>();
        }

        public int ScheduleDisciplineId { get; set; }
        public int FixedDisciplineId { get; set; }
        public DateTime Date { get; set; }
        public int PairNumber { get; set; }
        public int? AudienceId { get; set; }
        public bool? IsEvenPair { get; set; }
        public bool? IsFirstSubgroup { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedByEmployeeId { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Audience Audience { get; set; }
        public virtual Employee CreatedByEmployee { get; set; }
        public virtual FixedDiscipline FixedDiscipline { get; set; }
        public virtual Employee ModifiedByEmployee { get; set; }
        public virtual ICollection<ConductedPair> ConductedPairs { get; set; }
        public virtual ICollection<ScheduleDisciplineReplacement> ScheduleDisciplineReplacements { get; set; }
    }
}
