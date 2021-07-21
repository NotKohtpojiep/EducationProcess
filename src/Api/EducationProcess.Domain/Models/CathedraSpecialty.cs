using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class CathedraSpecialty
    {
        public int CathedraId { get; set; }
        public int FsesCategoryPatitionId { get; set; }

        public Cathedra Cathedra { get; set; }
        public FsesCategoryPartition FsesCategoryPatition { get; set; }
        public Specialty FsesCategoryPatitionNavigation { get; set; }
    }
}
