using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class CathedraSpecialtyService : ICathedraSpecialtyService
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CathedraSpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesByCathedraIdAsync(int cathedraId)
        {
            DataAccess.Entities.CathedraSpecialty[] cathedraSpecialty =
                await _unitOfWork.CathedraSpecialties.FindAllByWhereAsync(x => x.CathedraId == cathedraId);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty[], CathedraSpecialty[]>(cathedraSpecialty);
        }

        public async Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesBySpecialtyIdAsync(int fsesCategoryPatitionId)
        {
            DataAccess.Entities.CathedraSpecialty[] cathedraSpecialty =
                await _unitOfWork.CathedraSpecialties.FindAllByWhereAsync(x => x.FsesCategoryPartitionId == fsesCategoryPatitionId);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty[], CathedraSpecialty[]>(cathedraSpecialty);
        }


        public async Task<CathedraSpecialty[]> GetAllCathedraSpecialtiesAsync()
        {
            DataAccess.Entities.CathedraSpecialty[] cathedraSpecialty =
                await _unitOfWork.CathedraSpecialties.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty[], CathedraSpecialty[]>(cathedraSpecialty);
        }

        public async Task<CathedraSpecialty> AddCathedraSpecialtyAsync(CathedraSpecialty newCathedraSpecialty)
        {
            DataAccess.Entities.CathedraSpecialty cathedraSpecialty =
                _mapper.Map<CathedraSpecialty, DataAccess.Entities.CathedraSpecialty>(newCathedraSpecialty);

            cathedraSpecialty = await _unitOfWork.CathedraSpecialties.AddAsync(cathedraSpecialty);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty, CathedraSpecialty>(cathedraSpecialty);
        }

        public async Task<CathedraSpecialty[]> AddRangeCathedraSpecialtyAsync(CathedraSpecialty[] newCathedraSpecialties)
        {
            DataAccess.Entities.CathedraSpecialty[] cathedraSpecialtys =
                _mapper.Map<CathedraSpecialty[], DataAccess.Entities.CathedraSpecialty[]>(newCathedraSpecialties);

            cathedraSpecialtys = await _unitOfWork.CathedraSpecialties.AddRangeAsync(cathedraSpecialtys);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty[], CathedraSpecialty[]>(cathedraSpecialtys);
        }

        public async Task<CathedraSpecialty> UpdateCathedraSpecialtyAsync(CathedraSpecialty newCathedraSpecialty)
        {
            DataAccess.Entities.CathedraSpecialty cathedraSpecialty =
                _mapper.Map<CathedraSpecialty, DataAccess.Entities.CathedraSpecialty>(newCathedraSpecialty);

            cathedraSpecialty = await _unitOfWork.CathedraSpecialties.UpdateAsync(cathedraSpecialty);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty, CathedraSpecialty>(cathedraSpecialty);
        }

        public async Task<CathedraSpecialty[]> UpdateRangeCathedraSpecialtyAsync(CathedraSpecialty[] newCathedraSpecialty)
        {
            DataAccess.Entities.CathedraSpecialty[] cathedraSpecialty =
                _mapper.Map<CathedraSpecialty[], DataAccess.Entities.CathedraSpecialty[]>(newCathedraSpecialty);

            cathedraSpecialty = await _unitOfWork.CathedraSpecialties.UpdateRangeAsync(cathedraSpecialty);
            return _mapper.Map<DataAccess.Entities.CathedraSpecialty[], CathedraSpecialty[]>(cathedraSpecialty);
        }

        public async Task DeleteCathedraSpecialtyAsync(CathedraSpecialty cathedraSpecialty)
        {
            DataAccess.Entities.CathedraSpecialty mappedCathedraSpecialty =
                _mapper.Map<CathedraSpecialty, DataAccess.Entities.CathedraSpecialty>(cathedraSpecialty);

            await _unitOfWork.CathedraSpecialties.DeleteAsync(mappedCathedraSpecialty);
        }

        public async Task DeleteRangeCathedraSpecialtyAsync(CathedraSpecialty[] cathedraSpecialtys)
        {
            DataAccess.Entities.CathedraSpecialty[] mappedCathedraSpecialties =
                _mapper.Map<CathedraSpecialty[], DataAccess.Entities.CathedraSpecialty[]>(cathedraSpecialtys);

            await _unitOfWork.CathedraSpecialties.DeleteRangeAsync(mappedCathedraSpecialties);
        }
    }
}