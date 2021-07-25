namespace EducationProcess.Domain.Models
{
    public class CathedraSpecialty
    {
        public uint CathedraId { get; set; }
        public uint FsesCategoryPatitionId { get; set; }

        public Cathedra Cathedra { get; set; }
        public FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}