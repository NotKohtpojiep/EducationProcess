using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EducationProcess.ApiClient;
using EducationProcess.ApiClient.Models;

namespace EducationProcess.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            string apiUrl = "http://localhost:5004/";
            string accessToken =
                "eyJhbGciOiJSUzI1NiIsImtpZCI6IjI4QTEwMjczREQzN0FBQzI5QjM4QjBGRkQ5QjJFQjc3IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2Mjc3NTQ5ODYsImV4cCI6MTYyNzc1ODU4NiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiY2xpZW50X2lkIjoiY2xpZW50IiwianRpIjoiQTU2MjY4Q0EyNjMzRTEzODc2MDM5QjI5RkUyMTk0NTYiLCJpYXQiOjE2Mjc3NTQ5ODUsInNjb3BlIjpbImFwaTEiXX0.EnhUG7a_a1udY914IcXUiJS9P7Xm2OR7Qom9vOKRp8CTDen57zF10pF5X1V3GoRYaOCr0IbATBzRT4t70XmwlUNwEfmSOovdSm0sXHt-_M-v8ItgNAHOrw9vuwRaPU4glb1JQIBCYxhCI32tErLWC7TDmcf_7ZT1wV7eycfRWsaOy3u1dJ2sy0KpgYxqjG5Fv-J4RFNyASxeLbPTdYK1JDNq24JG4cmWOfCvrFgEFEhk8N-diPXvoYZ_pXPsgIVTxacSlG2pRPuYlya5T-CLOoPbJfGFsDhzMBrr2J2R1mJfEQsVMX2YFnXY_LBLbJk7XdNddsDIco55q8JzXSnGiQ";
                ApiClient.ApiClient.ConversationContext conversationContext =
                new ApiClient.ApiClient.ConversationContext(accessToken);
            ApiClient.ApiClient client = new ApiClient.ApiClient(apiUrl);
            MessageBox.Show(client.RestfulService<string>("WeatherForecast", HttpMethod.Get, conversationContext).Result.Response.ToString());
            */

        }

        private async Task check()
        {
            string apiUrl = "http://localhost:5004/";
            EducationProcessClient client = new EducationProcessClient(apiUrl);
            Post[] posts = await client.Posts.GetAllPostsAsync();
            string result = string.Join('\n', posts.Select(x => $"{x.PostId} - {x.Name}"));
            MessageBox.Show(result);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await check();
        }
    }
}