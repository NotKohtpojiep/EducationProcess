using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class EducationCyclesAndModule
    {

        public int EducationCycleId { get; set; }
        public string EducationCycleIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? EducationCycleParentId { get; set; }

        public  EducationCyclesAndModule EducationCycleParent { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<EducationCyclesAndModule> InverseEducationCycleParent { get; set; }
    }
}
