using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DisciplineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Discipline> GetDisciplineByIdAsync(int disciplineId)
        {
            DataAccess.Entities.Discipline discipline =
                await _unitOfWork.Disciplines.GetFirstWhereAsync(x => x.DisciplineId == disciplineId);
            return _mapper.Map<DataAccess.Entities.Discipline, Discipline>(discipline);
        }

        public async Task<Discipline[]> GetAllDisciplinesAsync()
        {
            DataAccess.Entities.Discipline[] discipline =
                await _unitOfWork.Disciplines.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Discipline[], Discipline[]>(discipline);
        }

        public async Task<Discipline[]> GetAllDisciplinesWithIncludeAsync()
        {
            DataAccess.Entities.Discipline[] discipline =
                await _unitOfWork.Disciplines.GetAllWithInclude();
            return _mapper.Map<DataAccess.Entities.Discipline[], Discipline[]>(discipline);
        }

        public async Task<Discipline> AddDisciplineAsync(Discipline newDiscipline)
        {
            DataAccess.Entities.Discipline discipline =
                _mapper.Map<Discipline, DataAccess.Entities.Discipline>(newDiscipline);

            discipline = await _unitOfWork.Disciplines.AddAsync(discipline);
            return _mapper.Map<DataAccess.Entities.Discipline, Discipline>(discipline);
        }

        public async Task<Discipline[]> AddRangeDisciplineAsync(Discipline[] newDisciplines)
        {
            DataAccess.Entities.Discipline[] disciplines =
                _mapper.Map<Discipline[], DataAccess.Entities.Discipline[]>(newDisciplines);

            disciplines = await _unitOfWork.Disciplines.AddRangeAsync(disciplines);
            return _mapper.Map<DataAccess.Entities.Discipline[], Discipline[]>(disciplines);
        }

        public async Task<Discipline> UpdateDisciplineAsync(Discipline newDiscipline)
        {
            DataAccess.Entities.Discipline discipline =
                _mapper.Map<Discipline, DataAccess.Entities.Discipline>(newDiscipline);

            discipline = await _unitOfWork.Disciplines.UpdateAsync(discipline);
            return _mapper.Map<DataAccess.Entities.Discipline, Discipline>(discipline);
        }

        public async Task<Discipline[]> UpdateRangeDisciplineAsync(Discipline[] newDiscipline)
        {
            DataAccess.Entities.Discipline[] discipline =
                _mapper.Map<Discipline[], DataAccess.Entities.Discipline[]>(newDiscipline);

            discipline = await _unitOfWork.Disciplines.UpdateRangeAsync(discipline);
            return _mapper.Map<DataAccess.Entities.Discipline[], Discipline[]>(discipline);
        }

        public async Task DeleteDisciplineAsync(Discipline discipline)
        {
            DataAccess.Entities.Discipline mappedDiscipline =
                _mapper.Map<Discipline, DataAccess.Entities.Discipline>(discipline);

            await _unitOfWork.Disciplines.DeleteAsync(mappedDiscipline);
        }

        public async Task DeleteRangeDisciplineAsync(Discipline[] disciplines)
        {
            DataAccess.Entities.Discipline[] mappedDisciplines =
                _mapper.Map<Discipline[], DataAccess.Entities.Discipline[]>(disciplines);

            await _unitOfWork.Disciplines.DeleteRangeAsync(mappedDisciplines);
        }
    }
}