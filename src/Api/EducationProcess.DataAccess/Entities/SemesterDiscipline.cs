using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class SemesterDiscipline
    {
        public SemesterDiscipline()
        {
            EducationPlanSemesterDisciplines = new HashSet<EducationPlanSemesterDiscipline>();
            FixedDisciplines = new HashSet<FixedDiscipline>();
        }

        public int SemesterDisciplineId { get; set; }
        public int SemesterId { get; set; }
        public int DisciplineId { get; set; }
        public short TheoryLessonHours { get; set; }
        public short PracticeWorkHours { get; set; }
        public short LaboratoryWorkHours { get; set; }
        public short ControlWorkHours { get; set; }
        public short IndependentWorkHours { get; set; }
        public short ConsultationHours { get; set; }
        public short ExamHours { get; set; }
        public short EducationalPracticeHours { get; set; }
        public short ProductionPracticeHours { get; set; }
        public int? CertificationFormId { get; set; }
        public string Description { get; set; }

        public virtual IntermediateCertificationForm CertificationForm { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<EducationPlanSemesterDiscipline> EducationPlanSemesterDisciplines { get; set; }
        public virtual ICollection<FixedDiscipline> FixedDisciplines { get; set; }
    }
}