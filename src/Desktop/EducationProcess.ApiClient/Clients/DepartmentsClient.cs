using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Departments.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class DepartmentsClient : IDepartmentsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal DepartmentsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Department> GetDepartmentAsync(int departmentId) =>
            await _httpFacade.Get<Department>($"Departments/{departmentId}");

        public async Task<Department[]> GetAllDepartmentsAsync() =>
            await _httpFacade.Get<Department[]>($"Departments/array");
    }
}