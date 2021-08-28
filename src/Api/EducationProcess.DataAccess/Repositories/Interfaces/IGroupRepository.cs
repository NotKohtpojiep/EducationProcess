using System;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Entities;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        Task<Group[]> GetAllCurrentGroupsByDate(DateTime date);
    }
}