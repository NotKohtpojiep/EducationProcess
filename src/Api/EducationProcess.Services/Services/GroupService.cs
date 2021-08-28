using System;
using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Group> GetGroupByIdAsync(int groupId)
        {
            DataAccess.Entities.Group group =
                await _unitOfWork.Groups.GetFirstWhereAsync(x => x.GroupId == groupId);
            return _mapper.Map<DataAccess.Entities.Group, Group>(group);
        }

        public async Task<Group[]> GetAllGroupsAsync()
        {
            DataAccess.Entities.Group[] group =
                await _unitOfWork.Groups.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Group[], Group[]>(group);
        }

        public async Task<Group[]> GetAllCurrentGroupsByDateAsync(DateTime date)
        {
            DataAccess.Entities.Group[] group =
                await _unitOfWork.Groups.GetAllCurrentGroupsByDate(date);
            return _mapper.Map<DataAccess.Entities.Group[], Group[]>(group);
        }

        public async Task<Group> AddGroupAsync(Group newGroup)
        {
            DataAccess.Entities.Group group =
                _mapper.Map<Group, DataAccess.Entities.Group>(newGroup);

            group = await _unitOfWork.Groups.AddAsync(group);
            return _mapper.Map<DataAccess.Entities.Group, Group>(group);
        }

        public async Task<Group[]> AddRangeGroupAsync(Group[] newGroups)
        {
            DataAccess.Entities.Group[] groups =
                _mapper.Map<Group[], DataAccess.Entities.Group[]>(newGroups);

            groups = await _unitOfWork.Groups.AddRangeAsync(groups);
            return _mapper.Map<DataAccess.Entities.Group[], Group[]>(groups);
        }

        public async Task<Group> UpdateGroupAsync(Group newGroup)
        {
            DataAccess.Entities.Group group =
                _mapper.Map<Group, DataAccess.Entities.Group>(newGroup);

            group = await _unitOfWork.Groups.UpdateAsync(group);
            return _mapper.Map<DataAccess.Entities.Group, Group>(group);
        }

        public async Task<Group[]> UpdateRangeGroupAsync(Group[] newGroup)
        {
            DataAccess.Entities.Group[] group =
                _mapper.Map<Group[], DataAccess.Entities.Group[]>(newGroup);

            group = await _unitOfWork.Groups.UpdateRangeAsync(group);
            return _mapper.Map<DataAccess.Entities.Group[], Group[]>(group);
        }

        public async Task DeleteGroupAsync(Group group)
        {
            DataAccess.Entities.Group mappedGroup =
                _mapper.Map<Group, DataAccess.Entities.Group>(group);

            await _unitOfWork.Groups.DeleteAsync(mappedGroup);
        }

        public async Task DeleteRangeGroupAsync(Group[] groups)
        {
            DataAccess.Entities.Group[] mappedGroups =
                _mapper.Map<Group[], DataAccess.Entities.Group[]>(groups);

            await _unitOfWork.Groups.DeleteRangeAsync(mappedGroups);
        }
    }
}