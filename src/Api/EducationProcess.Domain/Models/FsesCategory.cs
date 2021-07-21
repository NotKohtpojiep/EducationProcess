using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class FsesCategory
    {
        public int FsesCategoryId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
        public int FsesId { get; set; }

        public  FederalStateEducationalStandard Fses { get; set; }
        public List<FsesCategoryPartition> FsesCategoryPartitions { get; set; }
    }
}
