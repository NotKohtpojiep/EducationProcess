using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class AudienceTypeService : IAudienceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AudienceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AudienceType> GetAudienceTypeByIdAsync(int audienceTypeId)
        {
            DataAccess.Entities.AudienceType audienceType =
                await _unitOfWork.AudienceTypes.GetFirstWhereAsync(x => x.AudienceTypeId == audienceTypeId);
            return _mapper.Map<DataAccess.Entities.AudienceType, AudienceType>(audienceType);
        }

        public async Task<AudienceType[]> GetAllAudienceTypesAsync()
        {
            DataAccess.Entities.AudienceType[] audienceType =
                await _unitOfWork.AudienceTypes.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.AudienceType[], AudienceType[]>(audienceType);
        }

        public async Task<AudienceType> AddAudienceTypeAsync(AudienceType newAudienceType)
        {
            DataAccess.Entities.AudienceType audienceType =
                _mapper.Map<AudienceType, DataAccess.Entities.AudienceType>(newAudienceType);

            audienceType = await _unitOfWork.AudienceTypes.AddAsync(audienceType);
            return _mapper.Map<DataAccess.Entities.AudienceType, AudienceType>(audienceType);
        }

        public async Task<AudienceType[]> AddRangeAudienceTypeAsync(AudienceType[] newAudienceTypes)
        {
            DataAccess.Entities.AudienceType[] audienceTypes =
                _mapper.Map<AudienceType[], DataAccess.Entities.AudienceType[]>(newAudienceTypes);

            audienceTypes = await _unitOfWork.AudienceTypes.AddRangeAsync(audienceTypes);
            return _mapper.Map<DataAccess.Entities.AudienceType[], AudienceType[]>(audienceTypes);
        }

        public async Task<AudienceType> UpdateAudienceTypeAsync(AudienceType newAudienceType)
        {
            DataAccess.Entities.AudienceType audienceType =
                _mapper.Map<AudienceType, DataAccess.Entities.AudienceType>(newAudienceType);

            audienceType = await _unitOfWork.AudienceTypes.UpdateAsync(audienceType);
            return _mapper.Map<DataAccess.Entities.AudienceType, AudienceType>(audienceType);
        }

        public async Task<AudienceType[]> UpdateRangeAudienceTypeAsync(AudienceType[] newAudienceType)
        {
            DataAccess.Entities.AudienceType[] audienceType =
                _mapper.Map<AudienceType[], DataAccess.Entities.AudienceType[]>(newAudienceType);

            audienceType = await _unitOfWork.AudienceTypes.UpdateRangeAsync(audienceType);
            return _mapper.Map<DataAccess.Entities.AudienceType[], AudienceType[]>(audienceType);
        }

        public async Task DeleteAudienceTypeAsync(AudienceType audienceType)
        {
            DataAccess.Entities.AudienceType mappedAudienceType =
                _mapper.Map<AudienceType, DataAccess.Entities.AudienceType>(audienceType);

            await _unitOfWork.AudienceTypes.DeleteAsync(mappedAudienceType);
        }

        public async Task DeleteRangeAudienceTypeAsync(AudienceType[] audienceTypes)
        {
            DataAccess.Entities.AudienceType[] mappedAudienceTypes =
                _mapper.Map<AudienceType[], DataAccess.Entities.AudienceType[]>(audienceTypes);

            await _unitOfWork.AudienceTypes.DeleteRangeAsync(mappedAudienceTypes);
        }
    }
}