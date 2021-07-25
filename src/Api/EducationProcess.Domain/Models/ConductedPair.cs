namespace EducationProcess.Domain.Models
{
    public class ConductedPair
    {
        public uint ConductedPairId { get; set; }
        public uint? ScheduleDisciplineId { get; set; }
        public uint? ScheduleDisciplineReplacementId { get; set; }
        public uint LessonTypeId { get; set; }

        public LessonType LessonType { get; set; }
        public ScheduleDiscipline ScheduleDiscipline { get; set; }
        public ScheduleDisciplineReplacement ScheduleDisciplineReplacement { get; set; }
    }
}