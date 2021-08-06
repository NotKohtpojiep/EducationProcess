using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ISemesterService
    {
        Task<Semester> GetSemesterByIdAsync(int semesterId);
        Task<Semester[]> GetAllSemestersAsync();
        Task<Semester> AddSemesterAsync(Semester newSemester);
        Task<Semester[]> AddRangeSemesterAsync(Semester[] newSemesters);
        Task<Semester> UpdateSemesterAsync(Semester newSemester);
        Task<Semester[]> UpdateRangeSemesterAsync(Semester[] newSemester);
        Task DeleteSemesterAsync(Semester semester);
        Task DeleteRangeSemesterAsync(Semester[] semesters);
    }
}