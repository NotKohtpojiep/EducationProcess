namespace EducationProcess.Domain.Models
{
    public class FsesCategoryPartition
    {
        public uint FsesCategoryPatitionId { get; set; }
        public uint FirstPartNumber { get; set; }
        public uint SecondPartNumber { get; set; }
        public ushort? ThirdPathNumber { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public uint FsesCategoryId { get; set; }

        public FsesCategory FsesCategory { get; set; }
    }
}