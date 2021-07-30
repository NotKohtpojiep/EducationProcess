using System;
using EducationProcess.DataAccess.Repositories;
using EducationProcess.DataAccess.Repositories.Interfaces;

namespace EducationProcess.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly EducationProcessContext _context;
        private bool _disposed = false;

        private IAcademicYearRepository _academicYearRepository;
        private IAudienceRepository _audienceRepository;
        private IAudienceTypeRepository _audienceTypeRepository;
        private ICathedraRepository _cathedraRepository;
        private ICathedraSpecialtyRepository _cathedraSpecialtyRepository;
        private ICityRepository _cityRepository;
        private IConductedPairRepository _conductedPairRepository;
        private IDepartmentRepository _departmentRepository;
        private IDisciplineRepository _disciplineRepository;
        private IEducationCyclesAndModuleRepository _educationCyclesAndModuleRepository;
        private IEducationFormRepository _educationFormRepository;
        private IEducationLevelRepository _educationLevelRepository;
        private IEducationPlanRepository _educationPlanRepository;
        private IEducationPlanSemesterDisciplineRepository _educationPlanSemesterDisciplineRepository;
        private IEmployeeCathedraRepository _employeeCathedraRepository;
        private IEmployeeRepository _employeeRepository;
        private IFederalStateEducationalStandardRepository _federalStateEducationalStandardRepository;
        private IFixedDisciplineRepository _fixedDisciplineRepository;
        private IFsesCategoryPartitionRepository _fsesCategoryPartitionRepository;
        private IFsesCategoryRepository _fsesCategoryRepository;
        private IGroupRepository _groupRepository;
        private IIntermediateCertificationFormRepository _intermediateCertificationFormRepository;
        private ILessonTypeRepository _lessonTypeRepository;
        private IPostRepository _postRepository;
        private IReceivedEducationFormRepository _receivedEducationFormRepository;
        private IReceivedEducationRepository _receivedEducationRepository;
        private IReceivedSpecialtyRepository _receivedSpecialtyRepository;
        private IRegionRepository _regionRepository;
        private IScheduleDisciplineReplacementRepository _scheduleDisciplineReplacementRepository;
        private IScheduleDisciplineRepository _scheduleDisciplineRepository;
        private ISemesterDisciplineRepository _semesterDisciplineRepository;
        private ISemesterRepository _semesterRepository;
        private IStreetRepository _streetRepository;

        public UnitOfWork(EducationProcessContext context)
        {
            _context = context;
        }

        public IAcademicYearRepository AcademicYears => _academicYearRepository ??= new AcademicYearRepository(_context);
        public IAudienceRepository Audiences => _audienceRepository ??= new AudienceRepository(_context);
        public IAudienceTypeRepository AudienceTypes => _audienceTypeRepository ??= new AudienceTypeRepository(_context);
        public ICathedraRepository Cathedras => _cathedraRepository ??= new CathedraRepository(_context);
        public ICathedraSpecialtyRepository CathedraSpecialties => _cathedraSpecialtyRepository ??= new CathedraSpecialtyRepository(_context);
        public ICityRepository Cities => _cityRepository ??= new CityRepository(_context);
        public IConductedPairRepository ConductedPairs => _conductedPairRepository ??= new ConductedPairRepository(_context);
        public IDepartmentRepository Departments => _departmentRepository ??= new DepartmentRepository(_context);
        public IDisciplineRepository Disciplines => _disciplineRepository ??= new DisciplineRepository(_context);
        public IEducationCyclesAndModuleRepository EducationCyclesAndModules => _educationCyclesAndModuleRepository ??= new EducationCyclesAndModuleRepository(_context);
        public IEducationFormRepository EducationForms => _educationFormRepository ??= new EducationFormRepository(_context);
        public IEducationLevelRepository EducationLevels => _educationLevelRepository ??= new EducationLevelRepository(_context);
        public IEducationPlanRepository EducationPlans => _educationPlanRepository ??= new EducationPlanRepository(_context);
        public IEducationPlanSemesterDisciplineRepository EducationPlanSemesterDisciplines => _educationPlanSemesterDisciplineRepository ??= new EducationPlanSemesterDisciplineRepository(_context);
        public IEmployeeCathedraRepository EmployeeCathedras => _employeeCathedraRepository ??= new EmployeeCathedraRepository(_context);
        public IEmployeeRepository Employees => _employeeRepository ??= new EmployeeRepository(_context);
        public IFederalStateEducationalStandardRepository FederalStateEducationalStandards => _federalStateEducationalStandardRepository ??= new FederalStateEducationalStandardRepository(_context);
        public IFixedDisciplineRepository FixedDisciplines => _fixedDisciplineRepository ??= new FixedDisciplineRepository(_context);
        public IFsesCategoryPartitionRepository FsesCategoryPartitions => _fsesCategoryPartitionRepository ??= new FsesCategoryPartitionRepository(_context);
        public IFsesCategoryRepository FsesCategories => _fsesCategoryRepository ??= new FsesCategoryRepository(_context);
        public IGroupRepository Groups => _groupRepository ??= new GroupRepository(_context);
        public IIntermediateCertificationFormRepository IntermediateCertificationForms => _intermediateCertificationFormRepository ??= new IntermediateCertificationFormRepository(_context);
        public ILessonTypeRepository LessonTypes => _lessonTypeRepository ??= new LessonTypeRepository(_context);
        public IPostRepository Posts => _postRepository ??= new PostRepository(_context);
        public IReceivedEducationFormRepository ReceivedEducationForms => _receivedEducationFormRepository ??= new ReceivedEducationFormRepository(_context);
        public IReceivedEducationRepository ReceivedEducations => _receivedEducationRepository ??= new ReceivedEducationRepository(_context);
        public IReceivedSpecialtyRepository ReceivedSpecialties => _receivedSpecialtyRepository ??= new ReceivedSpecialtyRepository(_context);
        public IRegionRepository Regions => _regionRepository ??= new RegionRepository(_context);
        public IScheduleDisciplineReplacementRepository ScheduleDisciplineReplacements => _scheduleDisciplineReplacementRepository ??= new ScheduleDisciplineReplacementRepository(_context);
        public IScheduleDisciplineRepository ScheduleDisciplines => _scheduleDisciplineRepository ??= new ScheduleDisciplineRepository(_context);
        public ISemesterDisciplineRepository SemesterDisciplines => _semesterDisciplineRepository ??= new SemesterDisciplineRepository(_context);
        public ISemesterRepository Semesters => _semesterRepository ??= new SemesterRepository(_context);
        public IStreetRepository Streets => _streetRepository ??= new StreetRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}