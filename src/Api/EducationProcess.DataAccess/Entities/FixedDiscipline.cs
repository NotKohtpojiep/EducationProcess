using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class FixedDiscipline
    {
        public FixedDiscipline()
        {
            ScheduleDisciplineReplacements = new HashSet<ScheduleDisciplineReplacement>();
            ScheduleDisciplines = new HashSet<ScheduleDiscipline>();
        }

        public int FixedDisciplineId { get; set; }
        public int FixingEmployeeId { get; set; }
        public int SemesterDisciplineId { get; set; }
        public int GroupId { get; set; }
        public bool? IsAgreed { get; set; }
        public bool IsWatched { get; set; }
        public int FixerEmployeeId { get; set; }
        public string CommentByFixingEmployee { get; set; }
        public string CommentByFixerEmployee { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? CoordinatedAt { get; set; }

        public virtual Employee FixerEmployee { get; set; }
        public virtual Employee FixingEmployee { get; set; }
        public virtual Group Group { get; set; }
        public virtual SemesterDiscipline SemesterDiscipline { get; set; }
        public virtual ICollection<ScheduleDisciplineReplacement> ScheduleDisciplineReplacements { get; set; }
        public virtual ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
    }
}
