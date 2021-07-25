namespace EducationProcess.Domain.Models
{
    public class EducationCyclesAndModule
    {
        public uint EducationCycleId { get; set; }
        public string EducationCycleIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint? EducationCycleParentId { get; set; }

        public EducationCyclesAndModule EducationCycleParent { get; set; }
    }
}