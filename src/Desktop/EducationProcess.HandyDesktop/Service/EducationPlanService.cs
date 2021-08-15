using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models.EducationPlans.Requests;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;

namespace EducationProcess.HandyDesktop.Service
{
    public class EducationPlanService : IEducationPlanService
    {
        private readonly IEducationProcessClient _educationProcessClient;

        public EducationPlanService(IEducationProcessClient educationProcessClient)
        {
            _educationProcessClient = educationProcessClient;
        }

        public async Task<EducationPlan[]> GetAllEducationPlans()
        {
            return await _educationProcessClient.EducationPlans.GetAllEducationPlansAsync();
        }

        public async Task<EducationPlan> CreateEducationPlan(EducationPlan educationPlan)
        {
            EducationPlanRequest educationPlanRequest = new EducationPlanRequest()
            {
                Name = educationPlan.Name,
                Description = educationPlan.Description,
                AcademicYearId = educationPlan.AcademicYearId,
                FsesCategoryPartitionId = educationPlan.FsesCategoryPartitionId
            };
            return await _educationProcessClient.EducationPlans.CreateEducationPlanAsync(educationPlanRequest);
        }
    }
}
