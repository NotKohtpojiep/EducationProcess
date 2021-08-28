using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IFixedDisciplineRepository : IRepositoryBase<FixedDiscipline>
    {
        /// <summary>
        /// Получение диапозона записей о закрепляемых дисциплинах вместе с информацией о работниках, дисциплины с кафедрой и группы
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns>
        /// FixedDisciplines array with
        /// include EmployeeFixer and Post
        /// include FixingEmployee and Post
        /// include SemesterDiscipline and Discipline and Cathedra and Semester
        /// include Group
        /// </returns>
        Task<FixedDiscipline[]> GetRangeWithInclude(int offset, int limit);
        Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithInclude(int fixingEmployeeId);
        Task<FixedDiscipline[]> GetAllByGroupIdWithInclude(int groupId);
    }
}