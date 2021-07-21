using System;
using System.Collections.Generic;

namespace EducationProcess.Domain.Models

{
    public partial class Cathedra
    {

        public int CathedraId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public string Description { get; set; }

        public List<CathedraSpecialty> CathedraSpecialties { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<EmployeeCathedra> EmployeeCathedras { get; set; }
    }
}
