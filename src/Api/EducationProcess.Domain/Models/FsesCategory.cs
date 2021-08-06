namespace EducationProcess.Domain.Models
{
    public class FsesCategory
    {
        public int FsesCategoryId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
        public int FsesId { get; set; }

        public FederalStateEducationalStandard Fses { get; set; }
    }
}