using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<Department[]> GetAllDepartmentsAsync();
        Task<Department> AddDepartmentAsync(Department newDepartment);
        Task<Department[]> AddRangeDepartmentAsync(Department[] newDepartments);
        Task<Department> UpdateDepartmentAsync(Department newDepartment);
        Task<Department[]> UpdateRangeDepartmentAsync(Department[] newDepartment);
        Task DeleteDepartmentAsync(Department department);
        Task DeleteRangeDepartmentAsync(Department[] departments);
    }
}
