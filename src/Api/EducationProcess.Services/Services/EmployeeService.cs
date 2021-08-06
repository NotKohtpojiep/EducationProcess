using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            DataAccess.Entities.Employee employee =
                await _unitOfWork.Employees.GetFirstWhereAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<DataAccess.Entities.Employee, Employee>(employee);
        }

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            DataAccess.Entities.Employee[] employee =
                await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Employee[], Employee[]>(employee);
        }

        public async Task<Employee> AddEmployeeAsync(Employee newEmployee)
        {
            DataAccess.Entities.Employee employee =
                _mapper.Map<Employee, DataAccess.Entities.Employee>(newEmployee);

            employee = await _unitOfWork.Employees.AddAsync(employee);
            return _mapper.Map<DataAccess.Entities.Employee, Employee>(employee);
        }

        public async Task<Employee[]> AddRangeEmployeeAsync(Employee[] newEmployees)
        {
            DataAccess.Entities.Employee[] employees =
                _mapper.Map<Employee[], DataAccess.Entities.Employee[]>(newEmployees);

            employees = await _unitOfWork.Employees.AddRangeAsync(employees);
            return _mapper.Map<DataAccess.Entities.Employee[], Employee[]>(employees);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee newEmployee)
        {
            DataAccess.Entities.Employee employee =
                _mapper.Map<Employee, DataAccess.Entities.Employee>(newEmployee);

            employee = await _unitOfWork.Employees.UpdateAsync(employee);
            return _mapper.Map<DataAccess.Entities.Employee, Employee>(employee);
        }

        public async Task<Employee[]> UpdateRangeEmployeeAsync(Employee[] newEmployee)
        {
            DataAccess.Entities.Employee[] employee =
                _mapper.Map<Employee[], DataAccess.Entities.Employee[]>(newEmployee);

            employee = await _unitOfWork.Employees.UpdateRangeAsync(employee);
            return _mapper.Map<DataAccess.Entities.Employee[], Employee[]>(employee);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            DataAccess.Entities.Employee mappedEmployee =
                _mapper.Map<Employee, DataAccess.Entities.Employee>(employee);

            await _unitOfWork.Employees.DeleteAsync(mappedEmployee);
        }

        public async Task DeleteRangeEmployeeAsync(Employee[] employees)
        {
            DataAccess.Entities.Employee[] mappedEmployees =
                _mapper.Map<Employee[], DataAccess.Entities.Employee[]>(employees);

            await _unitOfWork.Employees.DeleteRangeAsync(mappedEmployees);
        }
    }
}