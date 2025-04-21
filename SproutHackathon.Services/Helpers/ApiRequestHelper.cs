using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using SproutHackathon.Services.ServiceCollection.AuthService;

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

        public async Task<HttpRequestMessage> CreateAuthorizedRequest(HttpMethod method, string relativeUrl)
        {
            var token = await _authService.GetAccessTokenAsync();
            var fullUrl = $"{_config["PartnerApi:ApiBaseUrl"]}/{relativeUrl}";

            var request = new HttpRequestMessage(method, fullUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("TenantCode", _config["PartnerApi:TenantCode"]);

            return request;
        }
    }
}
