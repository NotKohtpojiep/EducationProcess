using System;

namespace EducationProcess.ApiClient.Models.EducationPlans.Requests
{
    public class EducationPlanRequest
    {
        public int EducationPlanId { get; set; }
        public int FsesCategoryPartitionId { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public string Description { get; set; }
    }
}