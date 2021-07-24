using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class FsesCategoryPartitionRepository : RepositoryBase<FsesCategoryPartition>, IFsesCategoryPartitionRepository
    {
        private readonly EducationProcessContext context;
        
        public FsesCategoryPartitionRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}