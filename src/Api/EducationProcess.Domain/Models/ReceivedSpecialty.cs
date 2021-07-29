namespace EducationProcess.Domain.Models
{
    public class ReceivedSpecialty
    {
        public int ReceivedSpecialtyId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Qualification { get; set; }

        public FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}