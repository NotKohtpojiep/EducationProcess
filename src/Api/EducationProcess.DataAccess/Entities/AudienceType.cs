using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class AudienceType
    {
        public AudienceType()
        {
            Audiences = new HashSet<Audience>();
        }

        public int AudienceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Audience> Audiences { get; set; }
    }
}