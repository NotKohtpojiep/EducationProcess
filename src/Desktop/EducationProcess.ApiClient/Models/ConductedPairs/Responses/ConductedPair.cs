using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;

namespace EducationProcess.ApiClient.Models.ConductedPairs.Responses
{
    public class ConductedPair
    {
        public int ConductedPairId { get; set; }
        public int? ScheduleDisciplineId { get; set; }
        public int? ScheduleDisciplineReplacementId { get; set; }
        public int LessonTypeId { get; set; }

        public LessonType LessonType { get; set; }
        public ScheduleDiscipline ScheduleDiscipline { get; set; }
        public ScheduleDisciplineReplacement ScheduleDisciplineReplacement { get; set; }
    }
}