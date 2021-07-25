using System;

namespace EducationProcess.Domain.Models
{
    public class ScheduleDiscipline
    {
        public uint ScheduleDisciplineId { get; set; }
        public uint FixedDisciplineId { get; set; }
        public DateTime Date { get; set; }
        public uint PairNumber { get; set; }
        public uint? AudienceId { get; set; }
        public bool? IsEvenPair { get; set; }
        public bool? IsFirstSubgroup { get; set; }
        public uint CreatedByEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public uint ModifiedByEmployeeId { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Audience Audience { get; set; }
        public Employee CreatedByEmployee { get; set; }
        public FixedDiscipline FixedDiscipline { get; set; }
        public Employee ModifiedByEmployee { get; set; }
    }
}