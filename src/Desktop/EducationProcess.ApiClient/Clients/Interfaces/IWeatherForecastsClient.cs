using System.Threading.Tasks;
using EducationProcess.ApiClient.Models;

namespace EducationProcess.ApiClient.Clients.Interfaces
{
    public interface IWeatherForecastsClient
    {
        Task<WeatherForecast[]> GetAllWeatherForecastsAsync();
    }
}