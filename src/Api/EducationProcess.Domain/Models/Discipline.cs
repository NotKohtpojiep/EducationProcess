using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class Discipline
    {

        public int DisciplineId { get; set; }
        public string DisciplineIndex { get; set; }
        public int? CathedraId { get; set; }
        public int EducationCycleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public  Cathedra Cathedra { get; set; }
        public  EducationCyclesAndModule EducationCycle { get; set; }
        public List<SemesterDiscipline> SemesterDisciplines { get; set; }
    }
}
