using EducationProcess.DataAccess.Entities;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess.Repositories
{
    public class AcademicYearRepository : RepositoryBase<AcademicYear>, IAcademicYearRepository
    {
        private readonly EducationProcessContext context;
        
        public AcademicYearRepository(EducationProcessContext context) : base(context)
        {
            this.context = context;
        }
    }
}