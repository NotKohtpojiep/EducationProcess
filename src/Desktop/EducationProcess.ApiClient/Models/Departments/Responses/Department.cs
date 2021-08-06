namespace EducationProcess.ApiClient.Models.Departments.Responses
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StreetId { get; set; }
        public string HouseNumber { get; set; }
        public byte? BuildingNumber { get; set; }
        public int? PostalCode { get; set; }

        public Street Street { get; set; }
    }
}