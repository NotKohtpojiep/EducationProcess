using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class City
    {
        public City()
        {
            Streets = new HashSet<Street>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int? RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}