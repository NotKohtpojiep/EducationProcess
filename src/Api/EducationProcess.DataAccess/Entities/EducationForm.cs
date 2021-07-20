using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class EducationForm
    {
        public EducationForm()
        {
            ReceivedEducationForms = new HashSet<ReceivedEducationForm>();
        }

        public int EducationFormId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReceivedEducationForm> ReceivedEducationForms { get; set; }
    }
}
