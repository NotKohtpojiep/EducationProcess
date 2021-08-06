namespace EducationProcess.ApiClient.Models.Cathedras.Requests
{
    public class CathedraRequest
    {
        public int CathedraId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public string Description { get; set; }
    }
}