using EducationProcess.ApiClient.Models.Cathedras.Responses;

namespace EducationProcess.ApiClient.Models
{
    public class EmployeeCathedra
    {
        public int EmployeeId { get; set; }
        public int CathedraId { get; set; }

        public Cathedra Cathedra { get; set; }
        public Employee Employee { get; set; }
    }
}