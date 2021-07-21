using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class LessonType
    {

        public int LessonTypeId { get; set; }
        public string Name { get; set; }

        public List<ConductedPair> ConductedPairs { get; set; }
    }
}
