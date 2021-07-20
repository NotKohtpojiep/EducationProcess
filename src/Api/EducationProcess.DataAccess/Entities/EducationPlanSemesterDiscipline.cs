using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EducationPlanSemesterDiscipline
    {
        public int EducationPlanId { get; set; }
        public int SemesterDisciplineId { get; set; }

        public virtual EducationPlan EducationPlan { get; set; }
        public virtual SemesterDiscipline SemesterDiscipline { get; set; }
    }
}
