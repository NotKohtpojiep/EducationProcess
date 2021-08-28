using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FixedDisciplineService : IFixedDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FixedDisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FixedDiscipline> GetByIdAsync(int fixedDisciplineId)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetFirstWhereAsync(x => x.FixedDisciplineId == fixedDisciplineId);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> GetAllAsync()
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> GetRangeWithIncludeAsync(int offset = 1, int limit = 10)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetRangeWithInclude(offset, limit);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> GetAllByFixingEmployeeIdWithIncludeAsync(int fixingEmployeeId)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetAllByFixingEmployeeIdWithInclude(fixingEmployeeId);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> GetAllByGroupIdWithIncludeAsync(int groupId)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetAllByGroupIdWithInclude(groupId);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task<int> Count()
        {
            return await _unitOfWork.FixedDisciplines.Count();
        }

        public async Task<FixedDiscipline> AddAsync(FixedDiscipline newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.AddAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> AddRangeAsync(FixedDiscipline[] newFixedDisciplines)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDisciplines =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(newFixedDisciplines);

            fixedDisciplines = await _unitOfWork.FixedDisciplines.AddRangeAsync(fixedDisciplines);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDisciplines);
        }

        public async Task<FixedDiscipline> UpdateAsync(FixedDiscipline newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.UpdateAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> UpdateRangeAsync(FixedDiscipline[] newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.UpdateRangeAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task DeleteAsync(FixedDiscipline fixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline mappedFixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(fixedDiscipline);

            await _unitOfWork.FixedDisciplines.DeleteAsync(mappedFixedDiscipline);
        }

        public async Task DeleteRangeAsync(FixedDiscipline[] fixedDisciplines)
        {
            DataAccess.Entities.FixedDiscipline[] mappedFixedDisciplines =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(fixedDisciplines);

            await _unitOfWork.FixedDisciplines.DeleteRangeAsync(mappedFixedDisciplines);
        }
    }
}