using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class FsesCategoryService : IFsesCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FsesCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FsesCategory> GetFsesCategoryByIdAsync(int fsesCategoryId)
        {
            DataAccess.Entities.FsesCategory fsesCategory =
                await _unitOfWork.FsesCategories.GetFirstWhereAsync(x => x.FsesCategoryId == fsesCategoryId);
            return _mapper.Map<DataAccess.Entities.FsesCategory, FsesCategory>(fsesCategory);
        }

        public async Task<FsesCategory[]> GetAllFsesCategoriesAsync()
        {
            DataAccess.Entities.FsesCategory[] fsesCategory =
                await _unitOfWork.FsesCategories.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.FsesCategory[], FsesCategory[]>(fsesCategory);
        }

        public async Task<FsesCategory> AddFsesCategoryAsync(FsesCategory newFsesCategory)
        {
            DataAccess.Entities.FsesCategory fsesCategory =
                _mapper.Map<FsesCategory, DataAccess.Entities.FsesCategory>(newFsesCategory);

            fsesCategory = await _unitOfWork.FsesCategories.AddAsync(fsesCategory);
            return _mapper.Map<DataAccess.Entities.FsesCategory, FsesCategory>(fsesCategory);
        }

        public async Task<FsesCategory[]> AddRangeFsesCategoryAsync(FsesCategory[] newFsesCategories)
        {
            DataAccess.Entities.FsesCategory[] fsesCategorys =
                _mapper.Map<FsesCategory[], DataAccess.Entities.FsesCategory[]>(newFsesCategories);

            fsesCategorys = await _unitOfWork.FsesCategories.AddRangeAsync(fsesCategorys);
            return _mapper.Map<DataAccess.Entities.FsesCategory[], FsesCategory[]>(fsesCategorys);
        }

        public async Task<FsesCategory> UpdateFsesCategoryAsync(FsesCategory newFsesCategory)
        {
            DataAccess.Entities.FsesCategory fsesCategory =
                _mapper.Map<FsesCategory, DataAccess.Entities.FsesCategory>(newFsesCategory);

            fsesCategory = await _unitOfWork.FsesCategories.UpdateAsync(fsesCategory);
            return _mapper.Map<DataAccess.Entities.FsesCategory, FsesCategory>(fsesCategory);
        }

        public async Task<FsesCategory[]> UpdateRangeFsesCategoryAsync(FsesCategory[] newFsesCategory)
        {
            DataAccess.Entities.FsesCategory[] fsesCategory =
                _mapper.Map<FsesCategory[], DataAccess.Entities.FsesCategory[]>(newFsesCategory);

            fsesCategory = await _unitOfWork.FsesCategories.UpdateRangeAsync(fsesCategory);
            return _mapper.Map<DataAccess.Entities.FsesCategory[], FsesCategory[]>(fsesCategory);
        }

        public async Task DeleteFsesCategoryAsync(FsesCategory fsesCategory)
        {
            DataAccess.Entities.FsesCategory mappedFsesCategory =
                _mapper.Map<FsesCategory, DataAccess.Entities.FsesCategory>(fsesCategory);

            await _unitOfWork.FsesCategories.DeleteAsync(mappedFsesCategory);
        }

        public async Task DeleteRangeFsesCategoryAsync(FsesCategory[] fsesCategorys)
        {
            DataAccess.Entities.FsesCategory[] mappedFsesCategories =
                _mapper.Map<FsesCategory[], DataAccess.Entities.FsesCategory[]>(fsesCategorys);

            await _unitOfWork.FsesCategories.DeleteRangeAsync(mappedFsesCategories);
        }
    }
}