using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class ReceivedSpecialty
    {

        public int ReceivedSpecialtyId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Qualification { get; set; }

        public  FsesCategoryPartition FsesCategoryPatition { get; set; }
        public  Specialty FsesCategoryPatitionNavigation { get; set; }
        public List<ReceivedEducation> ReceivedEducations { get; set; }
    }
}
