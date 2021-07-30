using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class IntermediateCertificationFormService : IIntermediateCertificationFormService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IntermediateCertificationFormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IntermediateCertificationForm> GetIntermediateCertificationFormByIdAsync(int intermediateCertificationFormId)
        {
            DataAccess.Entities.IntermediateCertificationForm intermediateCertificationForm =
                await _unitOfWork.IntermediateCertificationForms.GetFirstWhereAsync(x => x.CertificationFormId == intermediateCertificationFormId);
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm, IntermediateCertificationForm>(intermediateCertificationForm);
        }

        public async Task<IntermediateCertificationForm[]> GetAllIntermediateCertificationFormsAsync()
        {
            DataAccess.Entities.IntermediateCertificationForm[] intermediateCertificationForm =
                await _unitOfWork.IntermediateCertificationForms.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm[], IntermediateCertificationForm[]>(intermediateCertificationForm);
        }

        public async Task<IntermediateCertificationForm> AddIntermediateCertificationFormAsync(IntermediateCertificationForm newIntermediateCertificationForm)
        {
            DataAccess.Entities.IntermediateCertificationForm intermediateCertificationForm =
                _mapper.Map<IntermediateCertificationForm, DataAccess.Entities.IntermediateCertificationForm>(newIntermediateCertificationForm);

            intermediateCertificationForm = await _unitOfWork.IntermediateCertificationForms.AddAsync(intermediateCertificationForm);
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm, IntermediateCertificationForm>(intermediateCertificationForm);
        }

        public async Task<IntermediateCertificationForm[]> AddRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] newIntermediateCertificationForms)
        {
            DataAccess.Entities.IntermediateCertificationForm[] intermediateCertificationForms =
                _mapper.Map<IntermediateCertificationForm[], DataAccess.Entities.IntermediateCertificationForm[]>(newIntermediateCertificationForms);

            intermediateCertificationForms = await _unitOfWork.IntermediateCertificationForms.AddRangeAsync(intermediateCertificationForms);
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm[], IntermediateCertificationForm[]>(intermediateCertificationForms);
        }

        public async Task<IntermediateCertificationForm> UpdateIntermediateCertificationFormAsync(IntermediateCertificationForm newIntermediateCertificationForm)
        {
            DataAccess.Entities.IntermediateCertificationForm intermediateCertificationForm =
                _mapper.Map<IntermediateCertificationForm, DataAccess.Entities.IntermediateCertificationForm>(newIntermediateCertificationForm);

            intermediateCertificationForm = await _unitOfWork.IntermediateCertificationForms.UpdateAsync(intermediateCertificationForm);
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm, IntermediateCertificationForm>(intermediateCertificationForm);
        }

        public async Task<IntermediateCertificationForm[]> UpdateRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] newIntermediateCertificationForm)
        {
            DataAccess.Entities.IntermediateCertificationForm[] intermediateCertificationForm =
                _mapper.Map<IntermediateCertificationForm[], DataAccess.Entities.IntermediateCertificationForm[]>(newIntermediateCertificationForm);

            intermediateCertificationForm = await _unitOfWork.IntermediateCertificationForms.UpdateRangeAsync(intermediateCertificationForm);
            return _mapper.Map<DataAccess.Entities.IntermediateCertificationForm[], IntermediateCertificationForm[]>(intermediateCertificationForm);
        }

        public async Task DeleteIntermediateCertificationFormAsync(IntermediateCertificationForm intermediateCertificationForm)
        {
            DataAccess.Entities.IntermediateCertificationForm mappedIntermediateCertificationForm =
                _mapper.Map<IntermediateCertificationForm, DataAccess.Entities.IntermediateCertificationForm>(intermediateCertificationForm);

            await _unitOfWork.IntermediateCertificationForms.DeleteAsync(mappedIntermediateCertificationForm);
        }

        public async Task DeleteRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] intermediateCertificationForms)
        {
            DataAccess.Entities.IntermediateCertificationForm[] mappedIntermediateCertificationForms =
                _mapper.Map<IntermediateCertificationForm[], DataAccess.Entities.IntermediateCertificationForm[]>(intermediateCertificationForms);

            await _unitOfWork.IntermediateCertificationForms.DeleteRangeAsync(mappedIntermediateCertificationForms);
        }
    }
}