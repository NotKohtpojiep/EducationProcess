#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class ConductedPair
    {
        public int ConductedPairId { get; set; }
        public int? ScheduleDisciplineId { get; set; }
        public int? ScheduleDisciplineReplacementId { get; set; }
        public int LessonTypeId { get; set; }

        public virtual LessonType LessonType { get; set; }
        public virtual ScheduleDiscipline ScheduleDiscipline { get; set; }
        public virtual ScheduleDisciplineReplacement ScheduleDisciplineReplacement { get; set; }
    }
}