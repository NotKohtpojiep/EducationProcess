using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class Specialty
    {

        public int SpecialtieId { get; set; }
        public string SpecialtieCode { get; set; }
        public string ImplementedSpecialtyName { get; set; }
        public string Abbreviation { get; set; }

        public List<CathedraSpecialty> CathedraSpecialties { get; set; }
        public List<EducationPlan> EducationPlans { get; set; }
        public List<ReceivedSpecialty> ReceivedSpecialties { get; set; }
    }
}
