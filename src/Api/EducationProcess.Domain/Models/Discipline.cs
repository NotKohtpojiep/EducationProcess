using System;

namespace EducationProcess.Domain.Models
{
    public class Discipline
    {
        public uint DisciplineId { get; set; }
        public string DisciplineIndex { get; set; }
        public uint? CathedraId { get; set; }
        public uint EducationCycleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Cathedra Cathedra { get; set; }
        public EducationCyclesAndModule EducationCycle { get; set; }
    }
}