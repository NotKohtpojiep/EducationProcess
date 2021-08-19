using System.Linq;
using EducationProcess.ApiClient.Models.Disciplines.Responses;
using EducationProcess.ApiClient.Models.Employees.Responses;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;
using EducationProcess.ApiClient.Models.Groups.Responses;
using EducationProcess.ApiClient.Models.SemesterDisciplines.Responses;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public class FixedDisciplineModel : ObservableObject
    {
        private FixedDiscipline[] _fixedDisciplines;
        public FixedDisciplineModel(FixedDiscipline[] fixedDisciplines)
        {
            _fixedDisciplines = fixedDisciplines;
        }

        public string FixingEmployeeFio
        {
            get => $"{FixingEmployee.Firstname} {FixingEmployee.Lastname} {FixingEmployee.Middlename}";
        }

        public string EmployeeFixerFio
        {
            get => $"{FixingEmployee.Firstname} {FixingEmployee.Lastname} {FixingEmployee.Middlename}";
        }

        public string GroupName
        {
            get => Group.Name;
        }
    
        public string SemesterNumbers
        {
            get => $"{string.Join(",", _fixedDisciplines.Select(x => x.SemesterDiscipline.Semester.Number).OrderBy(x => x))}";
        }

        public string DisciplineName
        {
            get => Discipline.Name;
        }

        public bool? IsAgreed
        {
            get => _fixedDisciplines.First().IsAgreed;
            set => _fixedDisciplines.ToList().ForEach(x => x.IsAgreed = value);
        }

        public Employee FixingEmployee
        {
            get => _fixedDisciplines.First().FixingEmployee;
        }
        public Employee EmployeeFixer
        {
            get => _fixedDisciplines.First().FixingEmployee;
        }

        public Group Group
        {
            get => _fixedDisciplines.First().Group;
        }

        public SemesterDiscipline[] SemesterDisciplines
        {
            get => _fixedDisciplines.Select(x => x.SemesterDiscipline).ToArray();
        }

        public Discipline Discipline
        {
            get => _fixedDisciplines.First().SemesterDiscipline.Discipline;
        }
    }
}
