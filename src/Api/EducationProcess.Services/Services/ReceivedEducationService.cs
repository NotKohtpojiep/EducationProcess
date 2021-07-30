using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedEducationService : IReceivedEducationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivedEducationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReceivedEducation> GetReceivedEducationByIdAsync(int receivedEducationId)
        {
            DataAccess.Entities.ReceivedEducation receivedEducation =
                await _unitOfWork.ReceivedEducations.GetFirstWhereAsync(x => x.ReceivedEducationId == receivedEducationId);
            return _mapper.Map<DataAccess.Entities.ReceivedEducation, ReceivedEducation>(receivedEducation);
        }

        public async Task<ReceivedEducation[]> GetAllReceivedEducationsAsync()
        {
            DataAccess.Entities.ReceivedEducation[] receivedEducation =
                await _unitOfWork.ReceivedEducations.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.ReceivedEducation[], ReceivedEducation[]>(receivedEducation);
        }

        public async Task<ReceivedEducation> AddReceivedEducationAsync(ReceivedEducation newReceivedEducation)
        {
            DataAccess.Entities.ReceivedEducation receivedEducation =
                _mapper.Map<ReceivedEducation, DataAccess.Entities.ReceivedEducation>(newReceivedEducation);

            receivedEducation = await _unitOfWork.ReceivedEducations.AddAsync(receivedEducation);
            return _mapper.Map<DataAccess.Entities.ReceivedEducation, ReceivedEducation>(receivedEducation);
        }

        public async Task<ReceivedEducation[]> AddRangeReceivedEducationAsync(ReceivedEducation[] newReceivedEducations)
        {
            DataAccess.Entities.ReceivedEducation[] receivedEducations =
                _mapper.Map<ReceivedEducation[], DataAccess.Entities.ReceivedEducation[]>(newReceivedEducations);

            receivedEducations = await _unitOfWork.ReceivedEducations.AddRangeAsync(receivedEducations);
            return _mapper.Map<DataAccess.Entities.ReceivedEducation[], ReceivedEducation[]>(receivedEducations);
        }

        public async Task<ReceivedEducation> UpdateReceivedEducationAsync(ReceivedEducation newReceivedEducation)
        {
            DataAccess.Entities.ReceivedEducation receivedEducation =
                _mapper.Map<ReceivedEducation, DataAccess.Entities.ReceivedEducation>(newReceivedEducation);

            receivedEducation = await _unitOfWork.ReceivedEducations.UpdateAsync(receivedEducation);
            return _mapper.Map<DataAccess.Entities.ReceivedEducation, ReceivedEducation>(receivedEducation);
        }

        public async Task<ReceivedEducation[]> UpdateRangeReceivedEducationAsync(ReceivedEducation[] newReceivedEducation)
        {
            DataAccess.Entities.ReceivedEducation[] receivedEducation =
                _mapper.Map<ReceivedEducation[], DataAccess.Entities.ReceivedEducation[]>(newReceivedEducation);

            receivedEducation = await _unitOfWork.ReceivedEducations.UpdateRangeAsync(receivedEducation);
            return _mapper.Map<DataAccess.Entities.ReceivedEducation[], ReceivedEducation[]>(receivedEducation);
        }

        public async Task DeleteReceivedEducationAsync(ReceivedEducation receivedEducation)
        {
            DataAccess.Entities.ReceivedEducation mappedReceivedEducation =
                _mapper.Map<ReceivedEducation, DataAccess.Entities.ReceivedEducation>(receivedEducation);

            await _unitOfWork.ReceivedEducations.DeleteAsync(mappedReceivedEducation);
        }

        public async Task DeleteRangeReceivedEducationAsync(ReceivedEducation[] receivedEducations)
        {
            DataAccess.Entities.ReceivedEducation[] mappedReceivedEducations =
                _mapper.Map<ReceivedEducation[], DataAccess.Entities.ReceivedEducation[]>(receivedEducations);

            await _unitOfWork.ReceivedEducations.DeleteRangeAsync(mappedReceivedEducations);
        }
    }
}