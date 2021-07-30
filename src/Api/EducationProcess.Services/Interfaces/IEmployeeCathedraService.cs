using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IEmployeeCathedraService
    {
        Task<EmployeeCathedra[]> GetAllEmployeeCathedraByCathedraIdAsync(int cathedraId);
        Task<EmployeeCathedra[]> GetAllEmployeeCathedraByEmployeeIdAsync(int employeeId);
        Task<EmployeeCathedra[]> GetAllEmployeeCathedrasAsync();
        Task<EmployeeCathedra> AddEmployeeCathedraAsync(EmployeeCathedra newEmployeeCathedra);
        Task<EmployeeCathedra[]> AddRangeEmployeeCathedraAsync(EmployeeCathedra[] newEmployeeCathedras);
        Task<EmployeeCathedra> UpdateEmployeeCathedraAsync(EmployeeCathedra newEmployeeCathedra);
        Task<EmployeeCathedra[]> UpdateRangeEmployeeCathedraAsync(EmployeeCathedra[] newEmployeeCathedra);
        Task DeleteEmployeeCathedraAsync(EmployeeCathedra employeeCathedra);
        Task DeleteRangeEmployeeCathedraAsync(EmployeeCathedra[] employeeCathedras);
    }
}