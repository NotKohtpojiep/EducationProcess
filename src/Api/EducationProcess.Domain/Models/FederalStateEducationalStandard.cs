using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class FederalStateEducationalStandard
    {

        public int FsesId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }

        public List<FsesCategory> FsesCategories { get; set; }
    }
}
