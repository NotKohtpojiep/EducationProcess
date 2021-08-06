using System;

namespace EducationProcess.ApiClient.Models.ScheduleDisciplines.Requests
{
    public class ScheduleDisciplineReplacementRequest
    {
        public int ScheduleDisciplineReplacementId { get; set; }
        public int? ScheduleDisciplineId { get; set; }
        public int FixedDisciplineId { get; set; }
        public DateTime Date { get; set; }
        public int PairNumber { get; set; }
        public int? AudienceId { get; set; }
        public bool? IsFirstSubgroup { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedByEmployeeId { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}