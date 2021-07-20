using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class FederalStateEducationalStandard
    {
        public FederalStateEducationalStandard()
        {
            FsesCategories = new HashSet<FsesCategory>();
        }

        public int FsesId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FsesCategory> FsesCategories { get; set; }
    }
}
