using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class Cathedra
    {
        public Cathedra()
        {
            CathedraSpecialties = new HashSet<CathedraSpecialty>();
            Disciplines = new HashSet<Discipline>();
            EmployeeCathedras = new HashSet<EmployeeCathedra>();
        }

        public int CathedraId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CathedraSpecialty> CathedraSpecialties { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<EmployeeCathedra> EmployeeCathedras { get; set; }
    }
}