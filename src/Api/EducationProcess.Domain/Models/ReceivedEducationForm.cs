using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class ReceivedEducationForm
    {

        public int ReceivedEducationFormId { get; set; }
        public int EducationFormId { get; set; }
        public string AdditionalInfo { get; set; }

        public  EducationForm EducationForm { get; set; }
        public List<ReceivedEducation> ReceivedEducations { get; set; }
    }
}
