using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class ReceivedEducationFormService : IReceivedEducationFormService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivedEducationFormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReceivedEducationForm> GetReceivedEducationFormByIdAsync(int receivedEducationFormId)
        {
            DataAccess.Entities.ReceivedEducationForm receivedEducationForm =
                await _unitOfWork.ReceivedEducationForms.GetFirstWhereAsync(x => x.ReceivedEducationFormId == receivedEducationFormId);
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm, ReceivedEducationForm>(receivedEducationForm);
        }

        public async Task<ReceivedEducationForm[]> GetAllReceivedEducationFormsAsync()
        {
            DataAccess.Entities.ReceivedEducationForm[] receivedEducationForm =
                await _unitOfWork.ReceivedEducationForms.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm[], ReceivedEducationForm[]>(receivedEducationForm);
        }

        public async Task<ReceivedEducationForm> AddReceivedEducationFormAsync(ReceivedEducationForm newReceivedEducationForm)
        {
            DataAccess.Entities.ReceivedEducationForm receivedEducationForm =
                _mapper.Map<ReceivedEducationForm, DataAccess.Entities.ReceivedEducationForm>(newReceivedEducationForm);

            receivedEducationForm = await _unitOfWork.ReceivedEducationForms.AddAsync(receivedEducationForm);
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm, ReceivedEducationForm>(receivedEducationForm);
        }

        public async Task<ReceivedEducationForm[]> AddRangeReceivedEducationFormAsync(ReceivedEducationForm[] newReceivedEducationForms)
        {
            DataAccess.Entities.ReceivedEducationForm[] receivedEducationForms =
                _mapper.Map<ReceivedEducationForm[], DataAccess.Entities.ReceivedEducationForm[]>(newReceivedEducationForms);

            receivedEducationForms = await _unitOfWork.ReceivedEducationForms.AddRangeAsync(receivedEducationForms);
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm[], ReceivedEducationForm[]>(receivedEducationForms);
        }

        public async Task<ReceivedEducationForm> UpdateReceivedEducationFormAsync(ReceivedEducationForm newReceivedEducationForm)
        {
            DataAccess.Entities.ReceivedEducationForm receivedEducationForm =
                _mapper.Map<ReceivedEducationForm, DataAccess.Entities.ReceivedEducationForm>(newReceivedEducationForm);

            receivedEducationForm = await _unitOfWork.ReceivedEducationForms.UpdateAsync(receivedEducationForm);
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm, ReceivedEducationForm>(receivedEducationForm);
        }

        public async Task<ReceivedEducationForm[]> UpdateRangeReceivedEducationFormAsync(ReceivedEducationForm[] newReceivedEducationForm)
        {
            DataAccess.Entities.ReceivedEducationForm[] receivedEducationForm =
                _mapper.Map<ReceivedEducationForm[], DataAccess.Entities.ReceivedEducationForm[]>(newReceivedEducationForm);

            receivedEducationForm = await _unitOfWork.ReceivedEducationForms.UpdateRangeAsync(receivedEducationForm);
            return _mapper.Map<DataAccess.Entities.ReceivedEducationForm[], ReceivedEducationForm[]>(receivedEducationForm);
        }

        public async Task DeleteReceivedEducationFormAsync(ReceivedEducationForm receivedEducationForm)
        {
            DataAccess.Entities.ReceivedEducationForm mappedReceivedEducationForm =
                _mapper.Map<ReceivedEducationForm, DataAccess.Entities.ReceivedEducationForm>(receivedEducationForm);

            await _unitOfWork.ReceivedEducationForms.DeleteAsync(mappedReceivedEducationForm);
        }

        public async Task DeleteRangeReceivedEducationFormAsync(ReceivedEducationForm[] receivedEducationForms)
        {
            DataAccess.Entities.ReceivedEducationForm[] mappedReceivedEducationForms =
                _mapper.Map<ReceivedEducationForm[], DataAccess.Entities.ReceivedEducationForm[]>(receivedEducationForms);

            await _unitOfWork.ReceivedEducationForms.DeleteRangeAsync(mappedReceivedEducationForms);
        }
    }
}