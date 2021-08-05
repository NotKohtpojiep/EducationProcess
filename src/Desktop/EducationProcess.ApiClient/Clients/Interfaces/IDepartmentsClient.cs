using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.Departments.Responses;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IDepartmentsClient
    {
        Task<Department> GetDepartmentAsync(int departmentId);
        Task<Department[]> GetAllDepartmentsAsync();
    }
}