using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class StreetService : IStreetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StreetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Street> GetStreetByIdAsync(int streetId)
        {
            DataAccess.Entities.Street street =
                await _unitOfWork.Streets.GetFirstWhereAsync(x => x.StreetId == streetId);
            return _mapper.Map<DataAccess.Entities.Street, Street>(street);
        }

        public async Task<Street[]> GetAllStreetsAsync()
        {
            DataAccess.Entities.Street[] street =
                await _unitOfWork.Streets.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.Street[], Street[]>(street);
        }

        public async Task<Street> AddStreetAsync(Street newStreet)
        {
            DataAccess.Entities.Street street =
                _mapper.Map<Street, DataAccess.Entities.Street>(newStreet);

            street = await _unitOfWork.Streets.AddAsync(street);
            return _mapper.Map<DataAccess.Entities.Street, Street>(street);
        }

        public async Task<Street[]> AddRangeStreetAsync(Street[] newStreets)
        {
            DataAccess.Entities.Street[] streets =
                _mapper.Map<Street[], DataAccess.Entities.Street[]>(newStreets);

            streets = await _unitOfWork.Streets.AddRangeAsync(streets);
            return _mapper.Map<DataAccess.Entities.Street[], Street[]>(streets);
        }

        public async Task<Street> UpdateStreetAsync(Street newStreet)
        {
            DataAccess.Entities.Street street =
                _mapper.Map<Street, DataAccess.Entities.Street>(newStreet);

            street = await _unitOfWork.Streets.UpdateAsync(street);
            return _mapper.Map<DataAccess.Entities.Street, Street>(street);
        }

        public async Task<Street[]> UpdateRangeStreetAsync(Street[] newStreet)
        {
            DataAccess.Entities.Street[] street =
                _mapper.Map<Street[], DataAccess.Entities.Street[]>(newStreet);

            street = await _unitOfWork.Streets.UpdateRangeAsync(street);
            return _mapper.Map<DataAccess.Entities.Street[], Street[]>(street);
        }

        public async Task DeleteStreetAsync(Street street)
        {
            DataAccess.Entities.Street mappedStreet =
                _mapper.Map<Street, DataAccess.Entities.Street>(street);

            await _unitOfWork.Streets.DeleteAsync(mappedStreet);
        }

        public async Task DeleteRangeStreetAsync(Street[] streets)
        {
            DataAccess.Entities.Street[] mappedStreets =
                _mapper.Map<Street[], DataAccess.Entities.Street[]>(streets);

            await _unitOfWork.Streets.DeleteRangeAsync(mappedStreets);
        }
    }
}