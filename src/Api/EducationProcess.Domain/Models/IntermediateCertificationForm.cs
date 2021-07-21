using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class IntermediateCertificationForm
    {

        public int CertificationFormId { get; set; }
        public string Name { get; set; }

        public List<SemesterDiscipline> SemesterDisciplines { get; set; }
    }
}
