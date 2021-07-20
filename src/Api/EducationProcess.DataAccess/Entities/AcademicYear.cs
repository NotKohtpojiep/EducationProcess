using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class AcademicYear
    {
        public AcademicYear()
        {
            EducationPlans = new HashSet<EducationPlan>();
        }

        public int AcademicYearId { get; set; }
        public short BeginingYear { get; set; }
        public short EndingYear { get; set; }

        public virtual ICollection<EducationPlan> EducationPlans { get; set; }
    }
}
