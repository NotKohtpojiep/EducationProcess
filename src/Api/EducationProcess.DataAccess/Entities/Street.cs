using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Street
    {
        public Street()
        {
            Departments = new HashSet<Department>();
        }

        public int StreetId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}