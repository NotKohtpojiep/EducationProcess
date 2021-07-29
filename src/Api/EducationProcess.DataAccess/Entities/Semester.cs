using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Semester
    {
        public Semester()
        {
            SemesterDisciplines = new HashSet<SemesterDiscipline>();
        }

        public int SemesterId { get; set; }
        public byte Number { get; set; }
        public byte WeeksCount { get; set; }

        public virtual ICollection<SemesterDiscipline> SemesterDisciplines { get; set; }
    }
}