using System;

namespace EducationProcess.Domain.Models
{
    public class FixedDiscipline
    {
        public uint FixedDisciplineId { get; set; }
        public uint FixingEmployeeId { get; set; }
        public uint SemesterDisciplineId { get; set; }
        public uint GroupId { get; set; }
        public bool? IsAgreed { get; set; }
        public uint FixerEmployeeId { get; set; }
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