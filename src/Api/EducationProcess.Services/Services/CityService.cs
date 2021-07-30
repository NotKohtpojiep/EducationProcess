using System.Threading.Tasks;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.Domain.Models;
using EducationProcess.Services.Interfaces;

namespace EducationProcess.Services.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            DataAccess.Entities.City city =
                await _unitOfWork.Cities.GetFirstWhereAsync(x => x.CityId == cityId);
            return _mapper.Map<DataAccess.Entities.City, City>(city);
        }

        public async Task<City[]> GetAllCitiesAsync()
        {
            DataAccess.Entities.City[] city =
                await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<DataAccess.Entities.City[], City[]>(city);
        }

        public async Task<City> AddCityAsync(City newCity)
        {
            DataAccess.Entities.City city =
                _mapper.Map<City, DataAccess.Entities.City>(newCity);

            city = await _unitOfWork.Cities.AddAsync(city);
            return _mapper.Map<DataAccess.Entities.City, City>(city);
        }

        public async Task<City[]> AddRangeCityAsync(City[] newCities)
        {
            DataAccess.Entities.City[] citys =
                _mapper.Map<City[], DataAccess.Entities.City[]>(newCities);

            citys = await _unitOfWork.Cities.AddRangeAsync(citys);
            return _mapper.Map<DataAccess.Entities.City[], City[]>(citys);
        }

        public async Task<City> UpdateCityAsync(City newCity)
        {
            DataAccess.Entities.City city =
                _mapper.Map<City, DataAccess.Entities.City>(newCity);

            city = await _unitOfWork.Cities.UpdateAsync(city);
            return _mapper.Map<DataAccess.Entities.City, City>(city);
        }

        public async Task<City[]> UpdateRangeCityAsync(City[] newCity)
        {
            DataAccess.Entities.City[] city =
                _mapper.Map<City[], DataAccess.Entities.City[]>(newCity);

            city = await _unitOfWork.Cities.UpdateRangeAsync(city);
            return _mapper.Map<DataAccess.Entities.City[], City[]>(city);
        }

        public async Task DeleteCityAsync(City city)
        {
            DataAccess.Entities.City mappedCity =
                _mapper.Map<City, DataAccess.Entities.City>(city);

            await _unitOfWork.Cities.DeleteAsync(mappedCity);
        }

        public async Task DeleteRangeCityAsync(City[] citys)
        {
            DataAccess.Entities.City[] mappedCities =
                _mapper.Map<City[], DataAccess.Entities.City[]>(citys);

            await _unitOfWork.Cities.DeleteRangeAsync(mappedCities);
        }
    }
}