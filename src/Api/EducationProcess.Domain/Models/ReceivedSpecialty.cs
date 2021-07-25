namespace EducationProcess.Domain.Models
{
    public class ReceivedSpecialty
    {
        public uint ReceivedSpecialtyId { get; set; }
        public uint FsesCategoryPatitionId { get; set; }
        public string Qualification { get; set; }

        public FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}