using System;
using EducationProcess.ApiClient.Models.Groups.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.ApiClient.Models.FixedDisciplines.Responses
{
    public class FixedDiscipline
    {
        public int FixedDisciplineId { get; set; }
        public int FixingEmployeeId { get; set; }
        public int SemesterDisciplineId { get; set; }
        public int GroupId { get; set; }
        public bool? IsAgreed { get; set; }
        public bool? IsWatched { get; set; }
        public int FixerEmployeeId { get; set; }
        public string CommentByFixingEmployee { get; set; }
        public string CommentByFixerEmployee { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? CoordinatedAt { get; set; }

        public Employee FixerEmployee { get; set; }
        public Employee FixingEmployee { get; set; }
        public Group Group { get; set; }
        public SemesterDiscipline SemesterDiscipline { get; set; }
    }
}