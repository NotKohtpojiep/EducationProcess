namespace EducationProcess.Domain.Models
{
    public class FsesCategory
    {
        public uint FsesCategoryId { get; set; }
        public ushort Number { get; set; }
        public string Name { get; set; }
        public uint FsesId { get; set; }

        public FederalStateEducationalStandard Fses { get; set; }
    }
}