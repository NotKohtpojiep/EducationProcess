namespace EducationProcess.Domain.Models
{
    public class SemesterDiscipline
    {
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

        public IntermediateCertificationForm CertificationForm { get; set; }
        public Discipline Discipline { get; set; }
        public Semester Semester { get; set; }
    }
}