using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedSpecialtyService : IReceivedSpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivedSpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReceivedSpecialty> GetReceivedSpecialtyByIdAsync(int receivedSpecialtyId)
        {
            DataAccess.Entities.ReceivedSpecialty receivedSpecialty =
                await _unitOfWork.ReceivedSpecialties.GetFirstWhereAsync(x => x.ReceivedSpecialtyId == receivedSpecialtyId);
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty, ReceivedSpecialty>(receivedSpecialty);
        }

        public async Task<ReceivedSpecialty[]> GetAllReceivedSpecialtiesAsync()
        {
            DataAccess.Entities.ReceivedSpecialty[] receivedSpecialty =
                await _unitOfWork.ReceivedSpecialties.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty[], ReceivedSpecialty[]>(receivedSpecialty);
        }

        public async Task<ReceivedSpecialty> AddReceivedSpecialtyAsync(ReceivedSpecialty newReceivedSpecialty)
        {
            DataAccess.Entities.ReceivedSpecialty receivedSpecialty =
                _mapper.Map<ReceivedSpecialty, DataAccess.Entities.ReceivedSpecialty>(newReceivedSpecialty);

            receivedSpecialty = await _unitOfWork.ReceivedSpecialties.AddAsync(receivedSpecialty);
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty, ReceivedSpecialty>(receivedSpecialty);
        }

        public async Task<ReceivedSpecialty[]> AddRangeReceivedSpecialtyAsync(ReceivedSpecialty[] newReceivedSpecialties)
        {
            DataAccess.Entities.ReceivedSpecialty[] receivedSpecialtys =
                _mapper.Map<ReceivedSpecialty[], DataAccess.Entities.ReceivedSpecialty[]>(newReceivedSpecialties);

            receivedSpecialtys = await _unitOfWork.ReceivedSpecialties.AddRangeAsync(receivedSpecialtys);
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty[], ReceivedSpecialty[]>(receivedSpecialtys);
        }

        public async Task<ReceivedSpecialty> UpdateReceivedSpecialtyAsync(ReceivedSpecialty newReceivedSpecialty)
        {
            DataAccess.Entities.ReceivedSpecialty receivedSpecialty =
                _mapper.Map<ReceivedSpecialty, DataAccess.Entities.ReceivedSpecialty>(newReceivedSpecialty);

            receivedSpecialty = await _unitOfWork.ReceivedSpecialties.UpdateAsync(receivedSpecialty);
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty, ReceivedSpecialty>(receivedSpecialty);
        }

        public async Task<ReceivedSpecialty[]> UpdateRangeReceivedSpecialtyAsync(ReceivedSpecialty[] newReceivedSpecialty)
        {
            DataAccess.Entities.ReceivedSpecialty[] receivedSpecialty =
                _mapper.Map<ReceivedSpecialty[], DataAccess.Entities.ReceivedSpecialty[]>(newReceivedSpecialty);

            receivedSpecialty = await _unitOfWork.ReceivedSpecialties.UpdateRangeAsync(receivedSpecialty);
            return _mapper.Map<DataAccess.Entities.ReceivedSpecialty[], ReceivedSpecialty[]>(receivedSpecialty);
        }

        public async Task DeleteReceivedSpecialtyAsync(ReceivedSpecialty receivedSpecialty)
        {
            DataAccess.Entities.ReceivedSpecialty mappedReceivedSpecialty =
                _mapper.Map<ReceivedSpecialty, DataAccess.Entities.ReceivedSpecialty>(receivedSpecialty);

            await _unitOfWork.ReceivedSpecialties.DeleteAsync(mappedReceivedSpecialty);
        }

        public async Task DeleteRangeReceivedSpecialtyAsync(ReceivedSpecialty[] receivedSpecialtys)
        {
            DataAccess.Entities.ReceivedSpecialty[] mappedReceivedSpecialties =
                _mapper.Map<ReceivedSpecialty[], DataAccess.Entities.ReceivedSpecialty[]>(receivedSpecialtys);

            await _unitOfWork.ReceivedSpecialties.DeleteRangeAsync(mappedReceivedSpecialties);
        }
    }
}