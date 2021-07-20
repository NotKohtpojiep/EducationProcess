using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; }
        public short BeginingYear { get; set; }
        public short EndingYear { get; set; }
        public List<EducationPlan> EducationPlans { get; set; }
    }
}
