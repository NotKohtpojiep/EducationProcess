using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Models;

namespace EducationProcess.ApiClient.Clients
{
    public sealed class WeatherForecastsClient : IWeatherForecastsClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;

        internal WeatherForecastsClient(EducationProcessHttpFacade httpFacade)
        {
            _httpFacade = httpFacade;
        }

        public async Task<WeatherForecast[]> GetAllWeatherForecastsAsync() =>
            await _httpFacade.Get<WeatherForecast[]>($"WeatherForecast");
    }
}