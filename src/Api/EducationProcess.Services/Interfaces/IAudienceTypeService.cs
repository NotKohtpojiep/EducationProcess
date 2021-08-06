using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IAudienceTypeService
    {
        Task<AudienceType> GetAudienceTypeByIdAsync(int audienceTypeId);
        Task<AudienceType[]> GetAllAudienceTypesAsync();
        Task<AudienceType> AddAudienceTypeAsync(AudienceType newAudienceType);
        Task<AudienceType[]> AddRangeAudienceTypeAsync(AudienceType[] newAudienceTypes);
        Task<AudienceType> UpdateAudienceTypeAsync(AudienceType newAudienceType);
        Task<AudienceType[]> UpdateRangeAudienceTypeAsync(AudienceType[] newAudienceType);
        Task DeleteAudienceTypeAsync(AudienceType audienceType);
        Task DeleteRangeAudienceTypeAsync(AudienceType[] audienceTypes);
    }
}