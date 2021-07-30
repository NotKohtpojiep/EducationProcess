using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class CathedraService : ICathedraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CathedraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Cathedra> GetCathedraByIdAsync(int cathedraId)
        {
            DataAccess.Entities.Cathedra cathedra =
                await _unitOfWork.Cathedras.GetFirstWhereAsync(x => x.CathedraId == cathedraId);
            return _mapper.Map<DataAccess.Entities.Cathedra, Cathedra>(cathedra);
        }

        public async Task<Cathedra[]> GetAllCathedrasAsync()
        {
            DataAccess.Entities.Cathedra[] cathedra =
                await _unitOfWork.Cathedras.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Cathedra[], Cathedra[]>(cathedra);
        }

        public async Task<Cathedra> AddCathedraAsync(Cathedra newCathedra)
        {
            DataAccess.Entities.Cathedra cathedra =
                _mapper.Map<Cathedra, DataAccess.Entities.Cathedra>(newCathedra);

            cathedra = await _unitOfWork.Cathedras.AddAsync(cathedra);
            return _mapper.Map<DataAccess.Entities.Cathedra, Cathedra>(cathedra);
        }

        public async Task<Cathedra[]> AddRangeCathedraAsync(Cathedra[] newCathedras)
        {
            DataAccess.Entities.Cathedra[] cathedras =
                _mapper.Map<Cathedra[], DataAccess.Entities.Cathedra[]>(newCathedras);

            cathedras = await _unitOfWork.Cathedras.AddRangeAsync(cathedras);
            return _mapper.Map<DataAccess.Entities.Cathedra[], Cathedra[]>(cathedras);
        }

        public async Task<Cathedra> UpdateCathedraAsync(Cathedra newCathedra)
        {
            DataAccess.Entities.Cathedra cathedra =
                _mapper.Map<Cathedra, DataAccess.Entities.Cathedra>(newCathedra);

            cathedra = await _unitOfWork.Cathedras.UpdateAsync(cathedra);
            return _mapper.Map<DataAccess.Entities.Cathedra, Cathedra>(cathedra);
        }

        public async Task<Cathedra[]> UpdateRangeCathedraAsync(Cathedra[] newCathedra)
        {
            DataAccess.Entities.Cathedra[] cathedra =
                _mapper.Map<Cathedra[], DataAccess.Entities.Cathedra[]>(newCathedra);

            cathedra = await _unitOfWork.Cathedras.UpdateRangeAsync(cathedra);
            return _mapper.Map<DataAccess.Entities.Cathedra[], Cathedra[]>(cathedra);
        }

        public async Task DeleteCathedraAsync(Cathedra cathedra)
        {
            DataAccess.Entities.Cathedra mappedCathedra =
                _mapper.Map<Cathedra, DataAccess.Entities.Cathedra>(cathedra);

            await _unitOfWork.Cathedras.DeleteAsync(mappedCathedra);
        }

        public async Task DeleteRangeCathedraAsync(Cathedra[] cathedras)
        {
            DataAccess.Entities.Cathedra[] mappedCathedras =
                _mapper.Map<Cathedra[], DataAccess.Entities.Cathedra[]>(cathedras);

            await _unitOfWork.Cathedras.DeleteRangeAsync(mappedCathedras);
        }
    }
}