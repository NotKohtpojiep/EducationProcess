using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface IFsesCategoryPartitionService
    {
        Task<FsesCategoryPartition> GetFsesCategoryPartitionByIdAsync(int fsesCategoryPartitionId);
        Task<FsesCategoryPartition[]> GetAllFsesCategoryPartitionsAsync();
        Task<FsesCategoryPartition> AddFsesCategoryPartitionAsync(FsesCategoryPartition newFsesCategoryPartition);
        Task<FsesCategoryPartition[]> AddRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] newFsesCategoryPartitions);
        Task<FsesCategoryPartition> UpdateFsesCategoryPartitionAsync(FsesCategoryPartition newFsesCategoryPartition);
        Task<FsesCategoryPartition[]> UpdateRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] newFsesCategoryPartition);
        Task DeleteFsesCategoryPartitionAsync(FsesCategoryPartition fsesCategoryPartition);
        Task DeleteRangeFsesCategoryPartitionAsync(FsesCategoryPartition[] fsesCategoryPartitions);
    }
}