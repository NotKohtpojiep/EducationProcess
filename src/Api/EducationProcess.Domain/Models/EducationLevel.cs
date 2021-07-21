using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class EducationLevel
    {

        public int EducationLevelId { get; set; }
        public string Name { get; set; }

        public List<ReceivedEducation> ReceivedEducations { get; set; }
    }
}
