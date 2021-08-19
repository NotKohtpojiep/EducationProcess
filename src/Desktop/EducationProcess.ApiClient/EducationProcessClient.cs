using System;
using System.Net.Http;
using System.Threading.Tasks;
using EducationProcess.ApiClient.Clients;
using EducationProcess.ApiClient.Clients.Interfaces;
using EducationProcess.ApiClient.Models.Oauth.Requests;
using EducationProcess.ApiClient.Internal.Http;
using EducationProcess.ApiClient.Internal.Http.Serialization;
using EducationProcess.ApiClient.Internal.Utilities;
using EducationProcess.ApiClient.Models.Oauth.Responses;

namespace EducationProcess.ApiClient
{
    public sealed class EducationProcessClient : IEducationProcessClient
    {
        private readonly EducationProcessHttpFacade _httpFacade;
        public EducationProcessClient(string hostUrl, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null)
        {
            Guard.NotEmpty(hostUrl, nameof(hostUrl));
            Guard.NotNull(authenticationToken, nameof(authenticationToken));
            HostUrl = FixBaseUrl(hostUrl);

            var jsonSerializer = new RequestsJsonSerializer();

            _httpFacade = new EducationProcessHttpFacade(
                HostUrl,
                jsonSerializer,
                authenticationToken,
                httpMessageHandler,
                clientTimeout);

            Audiences = new AudiencesClient(_httpFacade);
            Cathedras = new CathedrasClient(_httpFacade);
            ConductedPairs = new ConductedPairsClient(_httpFacade);
            Departments = new DepartmentsClient(_httpFacade);
            Disciplines = new DisciplinesClient(_httpFacade);
            EducationPlans = new EducationPlansClient(_httpFacade);
            EducationPlanSemesterDisciplines = new EducationPlanSemesterDisciplinesClient(_httpFacade);
            Employees = new EmployeesClient(_httpFacade);
            FederalStateEducationalStandards = new FederalStateEducationalStandardsClient(_httpFacade);
            FixedDisciplines = new FixedDisciplinesClient(_httpFacade);
            Groups = new GroupsClient(_httpFacade);
            Posts = new PostsClient(_httpFacade);
            ReceivedEducations = new ReceivedEducationsClient(_httpFacade);
            Schedules = new SchedulesClient(_httpFacade);
            SemesterDisciplines = new SemesterDisciplinesClient(_httpFacade);
            WeatherForecasts = new WeatherForecastsClient(_httpFacade);
        }

        public IAudiencesClient Audiences { get; }
        public ICathedrasClient Cathedras { get; }
        public IConductedPairsClient ConductedPairs { get; }
        public IDepartmentsClient Departments { get; }
        public IDisciplinesClient Disciplines { get; }
        public IEducationPlansClient EducationPlans { get; }
        public IEducationPlanSemesterDisciplinesClient EducationPlanSemesterDisciplines { get; }
        public IEmployeesClient Employees { get; }
        public IFederalStateEducationalStandardsClient FederalStateEducationalStandards { get; }
        public IFixedDisciplinesClient FixedDisciplines { get; }
        public IGroupsClient Groups { get; }
        public IPostsClient Posts { get; }
        public IReceivedEducationsClient ReceivedEducations { get; }
        public ISchedulesClient Schedules { get; }
        public ISemesterDisciplinesClient SemesterDisciplines { get; }
        public IWeatherForecastsClient WeatherForecasts { get; }

        public string HostUrl { get; }

        public Task<AccessTokenResponse> LoginAsync(string username, string password, string scope = "api")
        {
            Guard.NotEmpty(username, nameof(username));
            Guard.NotEmpty(password, nameof(password));
            var accessTokenRequest = new AccessTokenRequest
            {
                GrantType = "password",
                Scope = scope,
                Username = username,
                Password = password
            };
            return _httpFacade.LoginAsync(accessTokenRequest);
        }

        private static string FixBaseUrl(string url)
        {
            url = url.TrimEnd('/');

            if (!url.EndsWith("/api", StringComparison.OrdinalIgnoreCase))
                url += "/api";

            return url + "/";
        }
    }
}