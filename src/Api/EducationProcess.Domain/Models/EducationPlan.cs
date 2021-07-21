using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess.Domain.Models
{
    public class EducationPlan
    {
        public int EducationPlanId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public AcademicYear AcademicYear { get; set; }
        /*
        public FsesCategoryPartition FsesCategoryPatition { get; set; }
        public Specialty FsesCategoryPatitionNavigation { get; set; }
        public List<EducationPlanSemesterDiscipline> EducationPlanSemesterDisciplines { get; set; }
        public List<Group> Groups { get; set; }
        */
    }
}
