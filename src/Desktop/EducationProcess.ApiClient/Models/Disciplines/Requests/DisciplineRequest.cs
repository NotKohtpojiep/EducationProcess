namespace EducationProcess.ApiClient.Models.Disciplines.Requests
{
    public class DisciplineRequest
    {
        public int DisciplineId { get; set; }
        public string DisciplineIndex { get; set; }
        public int? CathedraId { get; set; }
        public int EducationCycleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}