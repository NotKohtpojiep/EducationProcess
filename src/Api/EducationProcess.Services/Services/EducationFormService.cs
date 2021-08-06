using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EducationFormService : IEducationFormService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationFormService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationForm> GetEducationFormByIdAsync(int educationFormId)
        {
            DataAccess.Entities.EducationForm educationForm =
                await _unitOfWork.EducationForms.GetFirstWhereAsync(x => x.EducationFormId == educationFormId);
            return _mapper.Map<DataAccess.Entities.EducationForm, EducationForm>(educationForm);
        }

        public async Task<EducationForm[]> GetAllEducationFormsAsync()
        {
            DataAccess.Entities.EducationForm[] educationForm =
                await _unitOfWork.EducationForms.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EducationForm[], EducationForm[]>(educationForm);
        }

        public async Task<EducationForm> AddEducationFormAsync(EducationForm newEducationForm)
        {
            DataAccess.Entities.EducationForm educationForm =
                _mapper.Map<EducationForm, DataAccess.Entities.EducationForm>(newEducationForm);

            educationForm = await _unitOfWork.EducationForms.AddAsync(educationForm);
            return _mapper.Map<DataAccess.Entities.EducationForm, EducationForm>(educationForm);
        }

        public async Task<EducationForm[]> AddRangeEducationFormAsync(EducationForm[] newEducationForms)
        {
            DataAccess.Entities.EducationForm[] educationForms =
                _mapper.Map<EducationForm[], DataAccess.Entities.EducationForm[]>(newEducationForms);

            educationForms = await _unitOfWork.EducationForms.AddRangeAsync(educationForms);
            return _mapper.Map<DataAccess.Entities.EducationForm[], EducationForm[]>(educationForms);
        }

        public async Task<EducationForm> UpdateEducationFormAsync(EducationForm newEducationForm)
        {
            DataAccess.Entities.EducationForm educationForm =
                _mapper.Map<EducationForm, DataAccess.Entities.EducationForm>(newEducationForm);

            educationForm = await _unitOfWork.EducationForms.UpdateAsync(educationForm);
            return _mapper.Map<DataAccess.Entities.EducationForm, EducationForm>(educationForm);
        }

        public async Task<EducationForm[]> UpdateRangeEducationFormAsync(EducationForm[] newEducationForm)
        {
            DataAccess.Entities.EducationForm[] educationForm =
                _mapper.Map<EducationForm[], DataAccess.Entities.EducationForm[]>(newEducationForm);

            educationForm = await _unitOfWork.EducationForms.UpdateRangeAsync(educationForm);
            return _mapper.Map<DataAccess.Entities.EducationForm[], EducationForm[]>(educationForm);
        }

        public async Task DeleteEducationFormAsync(EducationForm educationForm)
        {
            DataAccess.Entities.EducationForm mappedEducationForm =
                _mapper.Map<EducationForm, DataAccess.Entities.EducationForm>(educationForm);

            await _unitOfWork.EducationForms.DeleteAsync(mappedEducationForm);
        }

        public async Task DeleteRangeEducationFormAsync(EducationForm[] educationForms)
        {
            DataAccess.Entities.EducationForm[] mappedEducationForms =
                _mapper.Map<EducationForm[], DataAccess.Entities.EducationForm[]>(educationForms);

            await _unitOfWork.EducationForms.DeleteRangeAsync(mappedEducationForms);
        }
    }
}