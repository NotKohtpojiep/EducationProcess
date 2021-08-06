namespace EducationProcess.ApiClient.Models.ConductedPairs.Requests
{
    public class ConductedPairRequest
    {
        public int ConductedPairId { get; set; }
        public int? ScheduleDisciplineId { get; set; }
        public int? ScheduleDisciplineReplacementId { get; set; }
        public int LessonTypeId { get; set; }
    }
}