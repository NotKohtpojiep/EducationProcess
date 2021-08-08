using EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses;

namespace EducationProcess.ApiClient.Models.Cathedras.Responses
{
    public class CathedraSpecialty
    {
        public int CathedraId { get; set; }
        public int FsesCategoryPartitionId { get; set; }

        public Cathedra Cathedra { get; set; }
        public FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}