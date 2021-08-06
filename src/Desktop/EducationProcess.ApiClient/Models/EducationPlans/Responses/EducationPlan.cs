using System;
using EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses;

namespace EducationProcess.ApiClient.Models.EducationPlans.Responses
{
    public class EducationPlan
    {
        public int EducationPlanId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public AcademicYear AcademicYear { get; set; }
        public FsesCategoryPartition FsesCategoryPatition { get; set; }
    }
}