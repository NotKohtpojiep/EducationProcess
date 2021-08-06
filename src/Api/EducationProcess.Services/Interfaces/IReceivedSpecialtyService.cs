using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IReceivedSpecialtyService
    {
        Task<ReceivedSpecialty> GetReceivedSpecialtyByIdAsync(int receivedSpecialtyId);
        Task<ReceivedSpecialty[]> GetAllReceivedSpecialtiesAsync();
        Task<ReceivedSpecialty> AddReceivedSpecialtyAsync(ReceivedSpecialty newReceivedSpecialty);
        Task<ReceivedSpecialty[]> AddRangeReceivedSpecialtyAsync(ReceivedSpecialty[] newReceivedSpecialties);
        Task<ReceivedSpecialty> UpdateReceivedSpecialtyAsync(ReceivedSpecialty newReceivedSpecialty);
        Task<ReceivedSpecialty[]> UpdateRangeReceivedSpecialtyAsync(ReceivedSpecialty[] newReceivedSpecialty);
        Task DeleteReceivedSpecialtyAsync(ReceivedSpecialty receivedSpecialty);
        Task DeleteRangeReceivedSpecialtyAsync(ReceivedSpecialty[] receivedSpecialtys);
    }
}