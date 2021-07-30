using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class AudienceService : IAudienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AudienceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Audience> GetAudienceByIdAsync(int audienceId)
        {
            DataAccess.Entities.Audience audience =
                await _unitOfWork.Audiences.GetFirstWhereAsync(x => x.AudienceId == audienceId);
            return _mapper.Map<DataAccess.Entities.Audience, Audience>(audience);
        }

        public async Task<Audience[]> GetAllAudiencesAsync()
        {
            DataAccess.Entities.Audience[] audience =
                await _unitOfWork.Audiences.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Audience[], Audience[]>(audience);
        }

        public async Task<Audience> AddAudienceAsync(Audience newAudience)
        {
            DataAccess.Entities.Audience audience =
                _mapper.Map<Audience, DataAccess.Entities.Audience>(newAudience);

            audience = await _unitOfWork.Audiences.AddAsync(audience);
            return _mapper.Map<DataAccess.Entities.Audience, Audience>(audience);
        }

        public async Task<Audience[]> AddRangeAudienceAsync(Audience[] newAudiences)
        {
            DataAccess.Entities.Audience[] audiences =
                _mapper.Map<Audience[], DataAccess.Entities.Audience[]>(newAudiences);

            audiences = await _unitOfWork.Audiences.AddRangeAsync(audiences);
            return _mapper.Map<DataAccess.Entities.Audience[], Audience[]>(audiences);
        }

        public async Task<Audience> UpdateAudienceAsync(Audience newAudience)
        {
            DataAccess.Entities.Audience audience =
                _mapper.Map<Audience, DataAccess.Entities.Audience>(newAudience);

            audience = await _unitOfWork.Audiences.UpdateAsync(audience);
            return _mapper.Map<DataAccess.Entities.Audience, Audience>(audience);
        }

        public async Task<Audience[]> UpdateRangeAudienceAsync(Audience[] newAudience)
        {
            DataAccess.Entities.Audience[] audience =
                _mapper.Map<Audience[], DataAccess.Entities.Audience[]>(newAudience);

            audience = await _unitOfWork.Audiences.UpdateRangeAsync(audience);
            return _mapper.Map<DataAccess.Entities.Audience[], Audience[]>(audience);
        }

        public async Task DeleteAudienceAsync(Audience audience)
        {
            DataAccess.Entities.Audience mappedAudience =
                _mapper.Map<Audience, DataAccess.Entities.Audience>(audience);

            await _unitOfWork.Audiences.DeleteAsync(mappedAudience);
        }

        public async Task DeleteRangeAudienceAsync(Audience[] audiences)
        {
            DataAccess.Entities.Audience[] mappedAudiences =
                _mapper.Map<Audience[], DataAccess.Entities.Audience[]>(audiences);

            await _unitOfWork.Audiences.DeleteRangeAsync(mappedAudiences);
        }
    }
}