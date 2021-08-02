using System;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;

namespace EducationProcess.ApiClient.Models.EducationPlans.Requests
{
    public class CreateEducationPlanWithSemesterDisciplinesRequest
    {
        public int EducationPlanId { get; set; }
        public int FsesCategoryPatitionId { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public SemesterDiscipline[] SemesterDisciplines { get; set; }
    }
}