using System;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Data.Models;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IScheduleDisciplineService
    {
        Task<ScheduleDiscipline[]> GetCurrentScheduleByDateAsync(DateTime date);
        Task<ScheduleDiscipline[]> GetCurrentScheduleForTeacherAsync(int teacherId);
        Task<ScheduleDiscipline[]> GetCurrentScheduleForGroupAsync(int groupId);

        
        //TODO: Поменять место дислокации, им тут не место
        Task<LessonModel[]> GetEmptyLessonsForDay(LessonModel[] lessons);
        Task<ScheduleForDayModel[]> GetScheduleForWeek(ScheduleDiscipline[] scheduleDisciplines, FixedForInfo fixedFor);
        Task<GroupScheduleModel> GetScheduleForGroup(ScheduleDiscipline[] scheduleDisciplines);
    }
}
