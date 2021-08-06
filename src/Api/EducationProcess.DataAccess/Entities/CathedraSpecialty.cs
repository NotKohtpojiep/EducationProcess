﻿#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class CathedraSpecialty
    {
        public int CathedraId { get; set; }
        public int FsesCategoryPatitionId { get; set; }

        public virtual Cathedra Cathedra { get; set; }
        public virtual FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}