using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Employees.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IEmployeesClient
    {
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<Employee[]> GetAllEmployeesAsync();
    }
}