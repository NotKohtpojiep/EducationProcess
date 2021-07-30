using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class LessonTypeService : ILessonTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LessonType> GetLessonTypeByIdAsync(int lessonTypeId)
        {
            DataAccess.Entities.LessonType lessonType =
                await _unitOfWork.LessonTypes.GetFirstWhereAsync(x => x.LessonTypeId == lessonTypeId);
            return _mapper.Map<DataAccess.Entities.LessonType, LessonType>(lessonType);
        }

        public async Task<LessonType[]> GetAllLessonTypesAsync()
        {
            DataAccess.Entities.LessonType[] lessonType =
                await _unitOfWork.LessonTypes.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.LessonType[], LessonType[]>(lessonType);
        }

        public async Task<LessonType> AddLessonTypeAsync(LessonType newLessonType)
        {
            DataAccess.Entities.LessonType lessonType =
                _mapper.Map<LessonType, DataAccess.Entities.LessonType>(newLessonType);

            lessonType = await _unitOfWork.LessonTypes.AddAsync(lessonType);
            return _mapper.Map<DataAccess.Entities.LessonType, LessonType>(lessonType);
        }

        public async Task<LessonType[]> AddRangeLessonTypeAsync(LessonType[] newLessonTypes)
        {
            DataAccess.Entities.LessonType[] lessonTypes =
                _mapper.Map<LessonType[], DataAccess.Entities.LessonType[]>(newLessonTypes);

            lessonTypes = await _unitOfWork.LessonTypes.AddRangeAsync(lessonTypes);
            return _mapper.Map<DataAccess.Entities.LessonType[], LessonType[]>(lessonTypes);
        }

        public async Task<LessonType> UpdateLessonTypeAsync(LessonType newLessonType)
        {
            DataAccess.Entities.LessonType lessonType =
                _mapper.Map<LessonType, DataAccess.Entities.LessonType>(newLessonType);

            lessonType = await _unitOfWork.LessonTypes.UpdateAsync(lessonType);
            return _mapper.Map<DataAccess.Entities.LessonType, LessonType>(lessonType);
        }

        public async Task<LessonType[]> UpdateRangeLessonTypeAsync(LessonType[] newLessonType)
        {
            DataAccess.Entities.LessonType[] lessonType =
                _mapper.Map<LessonType[], DataAccess.Entities.LessonType[]>(newLessonType);

            lessonType = await _unitOfWork.LessonTypes.UpdateRangeAsync(lessonType);
            return _mapper.Map<DataAccess.Entities.LessonType[], LessonType[]>(lessonType);
        }

        public async Task DeleteLessonTypeAsync(LessonType lessonType)
        {
            DataAccess.Entities.LessonType mappedLessonType =
                _mapper.Map<LessonType, DataAccess.Entities.LessonType>(lessonType);

            await _unitOfWork.LessonTypes.DeleteAsync(mappedLessonType);
        }

        public async Task DeleteRangeLessonTypeAsync(LessonType[] lessonTypes)
        {
            DataAccess.Entities.LessonType[] mappedLessonTypes =
                _mapper.Map<LessonType[], DataAccess.Entities.LessonType[]>(lessonTypes);

            await _unitOfWork.LessonTypes.DeleteRangeAsync(mappedLessonTypes);
        }
    }
}