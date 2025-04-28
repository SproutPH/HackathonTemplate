using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SproutHackathon.Services.ServiceCollection.Sprout.AuthService;

namespace SproutHackathon.Services.Helpers
{
    public class ApiRequestHelper
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public ApiRequestHelper(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        public async Task<HttpRequestMessage> CreateSproutAuthRequest(HttpMethod method, string relativeUrl)
        {
            var token = await _authService.GetAccessTokenAsync();
            var fullUrl = $"{_config["PartnerApi:ApiBaseUrl"]}/{relativeUrl}";

            var request = new HttpRequestMessage(method, fullUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("TenantCode", _config["PartnerApi:TenantCode"]);

            return request;
        }

        public async Task<HttpRequestMessage> CreateEcoAuthRequest<T>(HttpMethod method, string appActionId, string token, T? body)
        {
            var fullUrl = $"{_config["PartnerApi:EcoBaseUrl"]}{appActionId}";
            var request = new HttpRequestMessage(method, fullUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (body != null)
            {
                var input = JsonSerializer.Serialize(body);
                request.Content = new StringContent(input, Encoding.UTF8, "application/json"); ; // This sets Content-Type to application/json
            }

            return request;
        }
    }
}
