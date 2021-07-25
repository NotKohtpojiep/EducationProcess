namespace EducationProcess.Domain.Models
{
    public class SemesterDiscipline
    {
        public uint SemesterDisciplineId { get; set; }
        public uint SemesterId { get; set; }
        public uint DisciplineId { get; set; }
        public ushort TheoryLessonHours { get; set; }
        public ushort PracticeWorkHours { get; set; }
        public ushort LaboratoryWorkHours { get; set; }
        public ushort ControlWorkHours { get; set; }
        public ushort IndependentWorkHours { get; set; }
        public ushort ConsultationHours { get; set; }
        public ushort ExamHours { get; set; }
        public ushort EducationalPracticeHours { get; set; }
        public ushort ProductionPracticeHours { get; set; }
        public uint? CertificationFormId { get; set; }
        public string Description { get; set; }

        public IntermediateCertificationForm CertificationForm { get; set; }
        public Discipline Discipline { get; set; }
        public Semester Semester { get; set; }
    }
}