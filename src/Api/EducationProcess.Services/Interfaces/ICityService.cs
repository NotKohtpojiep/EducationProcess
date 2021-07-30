using System.Threading.Tasks;
using EducationProcess.Domain.Models;

namespace EducationProcess.Services.Interfaces
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int cityId);
        Task<City[]> GetAllCitiesAsync();
        Task<City> AddCityAsync(City newCity);
        Task<City[]> AddRangeCityAsync(City[] newCities);
        Task<City> UpdateCityAsync(City newCity);
        Task<City[]> UpdateRangeCityAsync(City[] newCity);
        Task DeleteCityAsync(City city);
        Task DeleteRangeCityAsync(City[] citys);
    }
}