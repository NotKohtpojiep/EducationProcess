using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ILessonTypeService
    {
        Task<LessonType> GetLessonTypeByIdAsync(int lessonTypeId);
        Task<LessonType[]> GetAllLessonTypesAsync();
        Task<LessonType> AddLessonTypeAsync(LessonType newLessonType);
        Task<LessonType[]> AddRangeLessonTypeAsync(LessonType[] newLessonTypes);
        Task<LessonType> UpdateLessonTypeAsync(LessonType newLessonType);
        Task<LessonType[]> UpdateRangeLessonTypeAsync(LessonType[] newLessonType);
        Task DeleteLessonTypeAsync(LessonType lessonType);
        Task DeleteRangeLessonTypeAsync(LessonType[] lessonTypes);
    }
}