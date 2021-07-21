using System;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAcademicYearRepository AcademicYears { get; }
        IAudienceRepository Audiences { get; }
        IAudienceTypeRepository AudienceTypes { get; }
        ICathedraRepository Cathedras { get; }
        ICathedraSpecialtyRepository CathedraSpecialties { get; }
        IConductedPairRepository ConductedPairs { get; }
        IDisciplineRepository Disciplines { get; }
        IEducationCyclesAndModuleRepository EducationCyclesAndModules { get; }
        IEducationFormRepository EducationForms { get; }
        IEducationLevelRepository EducationLevels { get; }
        IEducationPlanRepository EducationPlans { get; }
        IEducationPlanSemesterDisciplineRepository EducationPlanSemesterDisciplines { get; }
        IEmployeeCathedraRepository EmployeeCathedra { get; }
        IEmployeeRepository Employees { get; }
        IFederalStateEducationalStandardRepository FederalStateEducationalStandard { get; }
        IFixedDisciplineRepository FixedDisciplines { get; }
        IFsesCategoryPartitionRepository FsesCategoryPartitions { get; }
        IFsesCategoryRepository FsesCategories { get; }
        IGroupRepository Groups { get; }
        IIntermediateCertificationFormRepository IntermediateCertificationForms { get; }
        ILessonTypeRepository LessonTypes { get; }
        IPostRepository Posts { get; }
        IReceivedEducationFormRepository ReceivedEducationForms { get; }
        IReceivedEducationRepository ReceivedEducations { get; }
        IReceivedSpecialtyRepository ReceivedSpecialties { get; }
        IScheduleDisciplineReplacementRepository ScheduleDisciplineReplacements { get; }
        IScheduleDisciplineRepository ScheduleDisciplines { get; }
        ISemesterDisciplineRepository SemesterDisciplines { get; }
        ISemesterRepository Semesters { get; }

        void Save();
    }
}
