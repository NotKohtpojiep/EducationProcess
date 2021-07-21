using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class EducationForm
    {

        public int EducationFormId { get; set; }
        public string Name { get; set; }

        public List<ReceivedEducationForm> ReceivedEducationForms { get; set; }
    }
}
