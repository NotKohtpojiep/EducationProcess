using AutoMapper;

namespace EducationProcess.Services
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<Domain.Models.AcademicYear, DataAccess.Entities.AcademicYear>().ReverseMap();
            CreateMap<Domain.Models.Audience, DataAccess.Entities.Audience>().ReverseMap();
            CreateMap<Domain.Models.AudienceType, DataAccess.Entities.AudienceType>().ReverseMap();
            CreateMap<Domain.Models.Cathedra, DataAccess.Entities.Cathedra>().ReverseMap();
            CreateMap<Domain.Models.CathedraSpecialty, DataAccess.Entities.CathedraSpecialty>().ReverseMap();
            CreateMap<Domain.Models.City, DataAccess.Entities.City>().ReverseMap();
            CreateMap<Domain.Models.ConductedPair, DataAccess.Entities.ConductedPair>().ReverseMap();
            CreateMap<Domain.Models.Discipline, DataAccess.Entities.Discipline>().ReverseMap();
            CreateMap<Domain.Models.Department, DataAccess.Entities.Department>().ReverseMap();
            CreateMap<Domain.Models.EducationCyclesAndModule, DataAccess.Entities.EducationCyclesAndModule>().ReverseMap();
            CreateMap<Domain.Models.EducationForm, DataAccess.Entities.EducationForm>().ReverseMap();
            CreateMap<Domain.Models.EducationLevel, DataAccess.Entities.EducationLevel>().ReverseMap();
            CreateMap<Domain.Models.EducationPlan, DataAccess.Entities.EducationPlan>().ReverseMap();
            CreateMap<Domain.Models.EducationPlanSemesterDiscipline, DataAccess.Entities.EducationPlanSemesterDiscipline>().ReverseMap();
            CreateMap<Domain.Models.Employee, DataAccess.Entities.Employee>().ReverseMap();
            CreateMap<Domain.Models.EmployeeCathedra, DataAccess.Entities.EmployeeCathedra>().ReverseMap();
            CreateMap<Domain.Models.FederalStateEducationalStandard, DataAccess.Entities.FederalStateEducationalStandard>().ReverseMap();
            CreateMap<Domain.Models.FixedDiscipline, DataAccess.Entities.FixedDiscipline>().ReverseMap();
            CreateMap<Domain.Models.FsesCategory, DataAccess.Entities.FsesCategory>().ReverseMap();
            CreateMap<Domain.Models.FsesCategoryPartition, DataAccess.Entities.FsesCategoryPartition>().ReverseMap();
            CreateMap<Domain.Models.Group, DataAccess.Entities.Group>().ReverseMap();
            CreateMap<Domain.Models.IntermediateCertificationForm, DataAccess.Entities.IntermediateCertificationForm>().ReverseMap();
            CreateMap<Domain.Models.LessonType, DataAccess.Entities.LessonType>().ReverseMap();
            CreateMap<Domain.Models.Post, DataAccess.Entities.Post>().ReverseMap();
            CreateMap<Domain.Models.ReceivedEducation, DataAccess.Entities.ReceivedEducation>().ReverseMap();
            CreateMap<Domain.Models.ReceivedEducationForm, DataAccess.Entities.ReceivedEducationForm>().ReverseMap();
            CreateMap<Domain.Models.ReceivedSpecialty, DataAccess.Entities.ReceivedSpecialty>().ReverseMap();
            CreateMap<Domain.Models.Region, DataAccess.Entities.Region>().ReverseMap();
            CreateMap<Domain.Models.ScheduleDiscipline, DataAccess.Entities.ScheduleDiscipline>().ReverseMap();
            CreateMap<Domain.Models.ScheduleDisciplineReplacement, DataAccess.Entities.ScheduleDisciplineReplacement>().ReverseMap();
            CreateMap<Domain.Models.SemesterDiscipline, DataAccess.Entities.SemesterDiscipline>().ReverseMap();
            CreateMap<Domain.Models.Semester, DataAccess.Entities.Semester>().ReverseMap();
            CreateMap<Domain.Models.Street, DataAccess.Entities.Street>().ReverseMap();
        }
    }
}