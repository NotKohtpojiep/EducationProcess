using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class AudienceType
    {

        public int AudienceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Audience> Audiences { get; set; }
    }
}
