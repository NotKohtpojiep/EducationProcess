using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Department
    {
        public Department()
        {
            Audiences = new HashSet<Audience>();
            Employees = new HashSet<Employee>();
            Groups = new HashSet<Group>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StreetId { get; set; }
        public string HouseNumber { get; set; }
        public byte? BuildingNumber { get; set; }
        public int? PostalCode { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Audience> Audiences { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}