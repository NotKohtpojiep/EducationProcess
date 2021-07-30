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

        public async Task<FixedDiscipline> GetFixedDisciplineByIdAsync(int fixedDisciplineId)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetFirstWhereAsync(x => x.FixedDisciplineId == fixedDisciplineId);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> GetAllFixedDisciplinesAsync()
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                await _unitOfWork.FixedDisciplines.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task<FixedDiscipline> AddFixedDisciplineAsync(FixedDiscipline newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.AddAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> AddRangeFixedDisciplineAsync(FixedDiscipline[] newFixedDisciplines)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDisciplines =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(newFixedDisciplines);

            fixedDisciplines = await _unitOfWork.FixedDisciplines.AddRangeAsync(fixedDisciplines);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDisciplines);
        }

        public async Task<FixedDiscipline> UpdateFixedDisciplineAsync(FixedDiscipline newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline fixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.UpdateAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline, FixedDiscipline>(fixedDiscipline);
        }

        public async Task<FixedDiscipline[]> UpdateRangeFixedDisciplineAsync(FixedDiscipline[] newFixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline[] fixedDiscipline =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(newFixedDiscipline);

            fixedDiscipline = await _unitOfWork.FixedDisciplines.UpdateRangeAsync(fixedDiscipline);
            return _mapper.Map<DataAccess.Entities.FixedDiscipline[], FixedDiscipline[]>(fixedDiscipline);
        }

        public async Task DeleteFixedDisciplineAsync(FixedDiscipline fixedDiscipline)
        {
            DataAccess.Entities.FixedDiscipline mappedFixedDiscipline =
                _mapper.Map<FixedDiscipline, DataAccess.Entities.FixedDiscipline>(fixedDiscipline);

            await _unitOfWork.FixedDisciplines.DeleteAsync(mappedFixedDiscipline);
        }

        public async Task DeleteRangeFixedDisciplineAsync(FixedDiscipline[] fixedDisciplines)
        {
            DataAccess.Entities.FixedDiscipline[] mappedFixedDisciplines =
                _mapper.Map<FixedDiscipline[], DataAccess.Entities.FixedDiscipline[]>(fixedDisciplines);

            await _unitOfWork.FixedDisciplines.DeleteRangeAsync(mappedFixedDisciplines);
        }
    }
}