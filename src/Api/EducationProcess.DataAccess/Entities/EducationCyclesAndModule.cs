using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EducationCyclesAndModule
    {
        public EducationCyclesAndModule()
        {
            Disciplines = new HashSet<Discipline>();
            InverseEducationCycleParent = new HashSet<EducationCyclesAndModule>();
        }

        public int EducationCycleId { get; set; }
        public string EducationCycleIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? EducationCycleParentId { get; set; }

        public virtual EducationCyclesAndModule EducationCycleParent { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<EducationCyclesAndModule> InverseEducationCycleParent { get; set; }
    }
}