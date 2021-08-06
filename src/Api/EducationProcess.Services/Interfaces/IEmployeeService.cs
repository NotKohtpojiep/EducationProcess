using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<Employee[]> GetAllEmployeesAsync();
        Task<Employee> AddEmployeeAsync(Employee newEmployee);
        Task<Employee[]> AddRangeEmployeeAsync(Employee[] newEmployees);
        Task<Employee> UpdateEmployeeAsync(Employee newEmployee);
        Task<Employee[]> UpdateRangeEmployeeAsync(Employee[] newEmployee);
        Task DeleteEmployeeAsync(Employee employee);
        Task DeleteRangeEmployeeAsync(Employee[] employees);
    }
}