using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient
{
    public interface IEducationProcessClient
    {
        IAudiencesClient Audiences { get; }
        ICathedrasClient Cathedras { get; }
        IConductedPairsClient ConductedPairs { get; }
        IDepartmentsClient Departments { get; }
        IDisciplinesClient Disciplines { get; }
        IEducationPlansClient EducationPlans { get; }
        IEducationPlanSemesterDisciplinesClient EducationPlanSemesterDisciplines { get; }
        IEmployeesClient Employees { get; }
        IFederalStateEducationalStandardsClient FederalStateEducationalStandards { get; }
        IFixedDisciplinesClient FixedDisciplines { get; }
        IGroupsClient Groups { get; }
        IPostsClient Posts { get; }
        IReceivedEducationsClient ReceivedEducations { get; }
        ISchedulesClient Schedules { get; }
        ISemesterDisciplinesClient SemesterDisciplines { get; }
        IWeatherForecastsClient WeatherForecasts { get; }

        string HostUrl { get; }

        Task<AccessTokenResponse> LoginAsync(string username, string password, string scope = "api");
    }
}