using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class Semester
    {

        public int SemesterId { get; set; }
        public byte Number { get; set; }
        public byte WeeksCount { get; set; }

        public List<SemesterDiscipline> SemesterDisciplines { get; set; }
    }
}
