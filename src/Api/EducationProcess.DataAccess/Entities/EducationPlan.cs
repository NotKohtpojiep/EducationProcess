using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EducationPlan
    {
        public EducationPlan()
        {
            EducationPlanSemesterDisciplines = new HashSet<EducationPlanSemesterDiscipline>();
            Groups = new HashSet<Group>();
        }

        public int EducationPlanId { get; set; }
        public int FsesCategoryPartitionId { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual FsesCategoryPartition FsesCategoryPatition { get; set; }
        public virtual ICollection<EducationPlanSemesterDiscipline> EducationPlanSemesterDisciplines { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}