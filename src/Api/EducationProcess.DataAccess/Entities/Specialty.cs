using System;
using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Specialty
    {
        public Specialty()
        {
            CathedraSpecialties = new HashSet<CathedraSpecialty>();
            EducationPlans = new HashSet<EducationPlan>();
            ReceivedSpecialties = new HashSet<ReceivedSpecialty>();
        }

        public int SpecialtieId { get; set; }
        public string SpecialtieCode { get; set; }
        public string ImplementedSpecialtyName { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<CathedraSpecialty> CathedraSpecialties { get; set; }
        public virtual ICollection<EducationPlan> EducationPlans { get; set; }
        public virtual ICollection<ReceivedSpecialty> ReceivedSpecialties { get; set; }
    }
}
