using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models.Employees.Responses;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class EmployeesClient : IEmployeesClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal EmployeesClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId) =>
            await _httpFacade.Get<Employee>($"Employees/{employeeId}");

        public async Task<Employee[]> GetAllEmployeesAsync() =>
            await _httpFacade.Get<Employee[]>($"Employees/array");
    }
}