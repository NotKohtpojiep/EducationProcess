using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            DataAccess.Entities.Department department =
                await _unitOfWork.Departments.GetFirstWhereAsync(x => x.DepartmentId == departmentId);
            return _mapper.Map<DataAccess.Entities.Department, Department>(department);
        }

        public async Task<Department[]> GetAllDepartmentsAsync()
        {
            DataAccess.Entities.Department[] department =
                await _unitOfWork.Departments.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Department[], Department[]>(department);
        }

        public async Task<Department> AddDepartmentAsync(Department newDepartment)
        {
            DataAccess.Entities.Department department =
                _mapper.Map<Department, DataAccess.Entities.Department>(newDepartment);

            department = await _unitOfWork.Departments.AddAsync(department);
            return _mapper.Map<DataAccess.Entities.Department, Department>(department);
        }

        public async Task<Department[]> AddRangeDepartmentAsync(Department[] newDepartments)
        {
            DataAccess.Entities.Department[] departments =
                _mapper.Map<Department[], DataAccess.Entities.Department[]>(newDepartments);

            departments = await _unitOfWork.Departments.AddRangeAsync(departments);
            return _mapper.Map<DataAccess.Entities.Department[], Department[]>(departments);
        }

        public async Task<Department> UpdateDepartmentAsync(Department newDepartment)
        {
            DataAccess.Entities.Department department =
                _mapper.Map<Department, DataAccess.Entities.Department>(newDepartment);

            department = await _unitOfWork.Departments.UpdateAsync(department);
            return _mapper.Map<DataAccess.Entities.Department, Department>(department);
        }

        public async Task<Department[]> UpdateRangeDepartmentAsync(Department[] newDepartment)
        {
            DataAccess.Entities.Department[] department =
                _mapper.Map<Department[], DataAccess.Entities.Department[]>(newDepartment);

            department = await _unitOfWork.Departments.UpdateRangeAsync(department);
            return _mapper.Map<DataAccess.Entities.Department[], Department[]>(department);
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            DataAccess.Entities.Department mappedDepartment =
                _mapper.Map<Department, DataAccess.Entities.Department>(department);

            await _unitOfWork.Departments.DeleteAsync(mappedDepartment);
        }

        public async Task DeleteRangeDepartmentAsync(Department[] departments)
        {
            DataAccess.Entities.Department[] mappedDepartments =
                _mapper.Map<Department[], DataAccess.Entities.Department[]>(departments);

            await _unitOfWork.Departments.DeleteRangeAsync(mappedDepartments);
        }
    }
}