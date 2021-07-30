using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class EmployeeCathedraService : IEmployeeCathedraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeCathedraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeCathedra[]> GetAllEmployeeCathedraByCathedraIdAsync(int cathedraId)
        {
            DataAccess.Entities.EmployeeCathedra[] employeeCathedras =
                await _unitOfWork.EmployeeCathedras.FindAllByWhereAsync(x => x.CathedraId == cathedraId);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra[], EmployeeCathedra[]>(employeeCathedras);
        }

        public async Task<EmployeeCathedra[]> GetAllEmployeeCathedraByEmployeeIdAsync(int employeeId)
        {
            DataAccess.Entities.EmployeeCathedra[] employeeCathedras =
                await _unitOfWork.EmployeeCathedras.FindAllByWhereAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra[], EmployeeCathedra[]>(employeeCathedras);
        }

        public async Task<EmployeeCathedra[]> GetAllEmployeeCathedrasAsync()
        {
            DataAccess.Entities.EmployeeCathedra[] employeeCathedra =
                await _unitOfWork.EmployeeCathedras.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra[], EmployeeCathedra[]>(employeeCathedra);
        }

        public async Task<EmployeeCathedra> AddEmployeeCathedraAsync(EmployeeCathedra newEmployeeCathedra)
        {
            DataAccess.Entities.EmployeeCathedra employeeCathedra =
                _mapper.Map<EmployeeCathedra, DataAccess.Entities.EmployeeCathedra>(newEmployeeCathedra);

            employeeCathedra = await _unitOfWork.EmployeeCathedras.AddAsync(employeeCathedra);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra, EmployeeCathedra>(employeeCathedra);
        }

        public async Task<EmployeeCathedra[]> AddRangeEmployeeCathedraAsync(EmployeeCathedra[] newEmployeeCathedras)
        {
            DataAccess.Entities.EmployeeCathedra[] employeeCathedras =
                _mapper.Map<EmployeeCathedra[], DataAccess.Entities.EmployeeCathedra[]>(newEmployeeCathedras);

            employeeCathedras = await _unitOfWork.EmployeeCathedras.AddRangeAsync(employeeCathedras);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra[], EmployeeCathedra[]>(employeeCathedras);
        }

        public async Task<EmployeeCathedra> UpdateEmployeeCathedraAsync(EmployeeCathedra newEmployeeCathedra)
        {
            DataAccess.Entities.EmployeeCathedra employeeCathedra =
                _mapper.Map<EmployeeCathedra, DataAccess.Entities.EmployeeCathedra>(newEmployeeCathedra);

            employeeCathedra = await _unitOfWork.EmployeeCathedras.UpdateAsync(employeeCathedra);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra, EmployeeCathedra>(employeeCathedra);
        }

        public async Task<EmployeeCathedra[]> UpdateRangeEmployeeCathedraAsync(EmployeeCathedra[] newEmployeeCathedra)
        {
            DataAccess.Entities.EmployeeCathedra[] employeeCathedra =
                _mapper.Map<EmployeeCathedra[], DataAccess.Entities.EmployeeCathedra[]>(newEmployeeCathedra);

            employeeCathedra = await _unitOfWork.EmployeeCathedras.UpdateRangeAsync(employeeCathedra);
            return _mapper.Map<DataAccess.Entities.EmployeeCathedra[], EmployeeCathedra[]>(employeeCathedra);
        }

        public async Task DeleteEmployeeCathedraAsync(EmployeeCathedra employeeCathedra)
        {
            DataAccess.Entities.EmployeeCathedra mappedEmployeeCathedra =
                _mapper.Map<EmployeeCathedra, DataAccess.Entities.EmployeeCathedra>(employeeCathedra);

            await _unitOfWork.EmployeeCathedras.DeleteAsync(mappedEmployeeCathedra);
        }

        public async Task DeleteRangeEmployeeCathedraAsync(EmployeeCathedra[] employeeCathedras)
        {
            DataAccess.Entities.EmployeeCathedra[] mappedEmployeeCathedras =
                _mapper.Map<EmployeeCathedra[], DataAccess.Entities.EmployeeCathedra[]>(employeeCathedras);

            await _unitOfWork.EmployeeCathedras.DeleteRangeAsync(mappedEmployeeCathedras);
        }
    }
}