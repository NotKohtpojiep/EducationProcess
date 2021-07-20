using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EducationLevel
    {
        public EducationLevel()
        {
            ReceivedEducations = new HashSet<ReceivedEducation>();
        }

        public int EducationLevelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReceivedEducation> ReceivedEducations { get; set; }
    }
}
