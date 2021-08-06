using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Discipline
    {
        public Discipline()
        {
            SemesterDisciplines = new HashSet<SemesterDiscipline>();
        }

        public int DisciplineId { get; set; }
        public string DisciplineIndex { get; set; }
        public int? CathedraId { get; set; }
        public int EducationCycleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Cathedra Cathedra { get; set; }
        public virtual EducationCyclesAndModule EducationCycle { get; set; }
        public virtual ICollection<SemesterDiscipline> SemesterDisciplines { get; set; }
    }
}