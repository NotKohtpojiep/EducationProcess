using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class ConductedPair
    {
        public int ConductedPairId { get; set; }
        public int? ScheduleDisciplineId { get; set; }
        public int? ScheduleDisciplineReplacementId { get; set; }
        public int LessonTypeId { get; set; }

        public LessonType LessonType { get; set; }
        public  ScheduleDiscipline ScheduleDiscipline { get; set; }
        public  ScheduleDisciplineReplacement ScheduleDisciplineReplacement { get; set; }
    }
}
