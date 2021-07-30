using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IIntermediateCertificationFormService
    {
        Task<IntermediateCertificationForm> GetIntermediateCertificationFormByIdAsync(int intermediateCertificationFormId);
        Task<IntermediateCertificationForm[]> GetAllIntermediateCertificationFormsAsync();
        Task<IntermediateCertificationForm> AddIntermediateCertificationFormAsync(IntermediateCertificationForm newIntermediateCertificationForm);
        Task<IntermediateCertificationForm[]> AddRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] newIntermediateCertificationForms);
        Task<IntermediateCertificationForm> UpdateIntermediateCertificationFormAsync(IntermediateCertificationForm newIntermediateCertificationForm);
        Task<IntermediateCertificationForm[]> UpdateRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] newIntermediateCertificationForm);
        Task DeleteIntermediateCertificationFormAsync(IntermediateCertificationForm intermediateCertificationForm);
        Task DeleteRangeIntermediateCertificationFormAsync(IntermediateCertificationForm[] intermediateCertificationForms);
    }
}