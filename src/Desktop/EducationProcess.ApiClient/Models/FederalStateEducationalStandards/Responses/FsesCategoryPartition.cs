namespace EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses
{
    public class FsesCategoryPartition
    {
        public int FsesCategoryPartitionId { get; set; }
        public int FirstPartNumber { get; set; }
        public int SecondPartNumber { get; set; }
        public short? ThirdPathNumber { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public int FsesCategoryId { get; set; }

        public FsesCategory FsesCategory { get; set; }
    }
}