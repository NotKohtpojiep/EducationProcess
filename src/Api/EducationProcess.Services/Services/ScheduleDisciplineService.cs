using System;
using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ScheduleDisciplineService : IScheduleDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleDisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ScheduleDiscipline> GetScheduleDisciplineByIdAsync(int scheduleDisciplineId)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                await _unitOfWork.ScheduleDisciplines.GetFirstWhereAsync(x => x.ScheduleDisciplineId == scheduleDisciplineId);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task<ScheduleDiscipline> AddScheduleDisciplineAsync(ScheduleDiscipline newScheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(newScheduleDiscipline);

            scheduleDiscipline = await _unitOfWork.ScheduleDisciplines.AddAsync(scheduleDiscipline);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task<ScheduleDiscipline[]> AddRangeScheduleDisciplineAsync(ScheduleDiscipline[] newScheduleDisciplines)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDisciplines =
                _mapper.Map<ScheduleDiscipline[], DataAccess.Entities.ScheduleDiscipline[]>(newScheduleDisciplines);

            scheduleDisciplines = await _unitOfWork.ScheduleDisciplines.AddRangeAsync(scheduleDisciplines);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDisciplines);
        }

        public async Task<ScheduleDiscipline> UpdateScheduleDisciplineAsync(ScheduleDiscipline newScheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline scheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(newScheduleDiscipline);

            scheduleDiscipline = await _unitOfWork.ScheduleDisciplines.UpdateAsync(scheduleDiscipline);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline, ScheduleDiscipline>(scheduleDiscipline);
        }

        public async Task<ScheduleDiscipline[]> UpdateRangeScheduleDisciplineAsync(ScheduleDiscipline[] newScheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDiscipline =
                _mapper.Map<ScheduleDiscipline[], DataAccess.Entities.ScheduleDiscipline[]>(newScheduleDiscipline);

            scheduleDiscipline = await _unitOfWork.ScheduleDisciplines.UpdateRangeAsync(scheduleDiscipline);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDiscipline);
        }

        public async Task DeleteScheduleDisciplineAsync(ScheduleDiscipline scheduleDiscipline)
        {
            DataAccess.Entities.ScheduleDiscipline mappedScheduleDiscipline =
                _mapper.Map<ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>(scheduleDiscipline);

            await _unitOfWork.ScheduleDisciplines.DeleteAsync(mappedScheduleDiscipline);
        }

        public async Task DeleteRangeScheduleDisciplineAsync(ScheduleDiscipline[] scheduleDisciplines)
        {
            DataAccess.Entities.ScheduleDiscipline[] mappedScheduleDisciplines =
                _mapper.Map<ScheduleDiscipline[], DataAccess.Entities.ScheduleDiscipline[]>(scheduleDisciplines);

            await _unitOfWork.ScheduleDisciplines.DeleteRangeAsync(mappedScheduleDisciplines);
        }

        public async Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(int departmentId, DateTime date)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDisciplines = 
                await _unitOfWork.ScheduleDisciplines.GetScheduleForWeekAndAllGroupsByDateAndDepartmentIdWithIncludeAsync(departmentId, date);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDisciplines);
        }

        public async Task<ScheduleDiscipline[]> GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(int teacherId, DateTime date)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDisciplines = 
                await _unitOfWork.ScheduleDisciplines.GetScheduleForWeekForTeacherByTeacherIdWithIncludeAsync(teacherId, date);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDisciplines);
        }

        public async Task<ScheduleDiscipline[]> GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(DateTime date)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDisciplines = 
                await _unitOfWork.ScheduleDisciplines.GetScheduleForWeekAndAllGroupsByDateWithIncludeAsync(date);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDisciplines);
        }

        public async Task<ScheduleDiscipline[]> GetScheduleForWeekByGroupIdWithIncludeAsync(int groupId)
        {
            DataAccess.Entities.ScheduleDiscipline[] scheduleDisciplines = 
                await _unitOfWork.ScheduleDisciplines.GetScheduleForWeekByGroupIdWithIncludeAsync(groupId);
            return _mapper.Map<DataAccess.Entities.ScheduleDiscipline[], ScheduleDiscipline[]>(scheduleDisciplines);
        }
    }
}