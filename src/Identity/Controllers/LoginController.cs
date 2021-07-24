using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(GetAccessToken().Result);
        }

        private async Task<string> GetAccessToken()
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return "null " + $"{this.Request.Scheme}://{this.Request.Host}";
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",

                Scope = "api1"
            });
            
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }
            return tokenResponse.AccessToken;
        }
    }
}