using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class FsesCategory
    {
        public FsesCategory()
        {
            FsesCategoryPartitions = new HashSet<FsesCategoryPartition>();
        }

        public int FsesCategoryId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
        public int FsesId { get; set; }

        public virtual FederalStateEducationalStandard Fses { get; set; }
        public virtual ICollection<FsesCategoryPartition> FsesCategoryPartitions { get; set; }
    }
}
