using System.Collections.Generic;

#nullable disable

namespace EducationProcess.DataAccess.Entities
{
    public partial class FsesCategoryPartition
    {
        public FsesCategoryPartition()
        {
            CathedraSpecialties = new HashSet<CathedraSpecialty>();
            EducationPlans = new HashSet<EducationPlan>();
            ReceivedSpecialties = new HashSet<ReceivedSpecialty>();
        }

        public int FsesCategoryPatitionId { get; set; }
        public int FirstPartNumber { get; set; }
        public int SecondPartNumber { get; set; }
        public short? ThirdPathNumber { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public int FsesCategoryId { get; set; }

        public virtual FsesCategory FsesCategory { get; set; }
        public virtual ICollection<CathedraSpecialty> CathedraSpecialties { get; set; }
        public virtual ICollection<EducationPlan> EducationPlans { get; set; }
        public virtual ICollection<ReceivedSpecialty> ReceivedSpecialties { get; set; }
    }
}