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
        ICityRepository Cities { get; }
        IConductedPairRepository ConductedPairs { get; }
        IDepartmentRepository Departments { get; }
        IDisciplineRepository Disciplines { get; }
        IEducationCyclesAndModuleRepository EducationCyclesAndModules { get; }
        IEducationFormRepository EducationForms { get; }
        IEducationLevelRepository EducationLevels { get; }
        IEducationPlanRepository EducationPlans { get; }
        IEducationPlanSemesterDisciplineRepository EducationPlanSemesterDisciplines { get; }
        IEmployeeCathedraRepository EmployeeCathedras { get; }
        IEmployeeRepository Employees { get; }
        IFederalStateEducationalStandardRepository FederalStateEducationalStandards { get; }
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
        IRegionRepository Regions { get; }
        IScheduleDisciplineReplacementRepository ScheduleDisciplineReplacements { get; }
        IScheduleDisciplineRepository ScheduleDisciplines { get; }
        ISemesterDisciplineRepository SemesterDisciplines { get; }
        ISemesterRepository Semesters { get; }
        IStreetRepository Streets { get; }

        void Save();
    }
}
