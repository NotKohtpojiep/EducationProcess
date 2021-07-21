using System;
using System.Collections.Generic;


namespace EducationProcess.Domain.Models

{
    public partial class FsesCategoryPartition
    {

        public int FsesCategoryPatitionId { get; set; }
        public int FirstPartNumber { get; set; }
        public int SecondPartNumber { get; set; }
        public short? ThirdPathNumber { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public int FsesCategoryId { get; set; }

        public virtual FsesCategory FsesCategory { get; set; }
        public List<CathedraSpecialty> CathedraSpecialties { get; set; }
        public List<EducationPlan> EducationPlans { get; set; }
        public List<ReceivedSpecialty> ReceivedSpecialties { get; set; }
    }
}
