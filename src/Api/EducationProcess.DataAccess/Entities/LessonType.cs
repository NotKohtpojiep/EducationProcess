using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class LessonType
    {
        public LessonType()
        {
            ConductedPairs = new HashSet<ConductedPair>();
        }

        public int LessonTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConductedPair> ConductedPairs { get; set; }
    }
}