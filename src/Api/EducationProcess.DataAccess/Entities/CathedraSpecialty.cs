#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class CathedraSpecialty
    {
        public int CathedraId { get; set; }
        public int FsesCategoryPartitionId { get; set; }

        public virtual Cathedra Cathedra { get; set; }
        public virtual FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}