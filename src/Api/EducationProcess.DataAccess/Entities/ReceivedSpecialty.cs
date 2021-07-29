using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class ReceivedSpecialty
    {
        public ReceivedSpecialty()
        {
            ReceivedEducations = new HashSet<ReceivedEducation>();
        }

        public int ReceivedSpecialtyId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Qualification { get; set; }

        public virtual FsesCategoryPartition FsesCategoryPatition { get; set; }
        public virtual ICollection<ReceivedEducation> ReceivedEducations { get; set; }
    }
}