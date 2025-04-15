using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using SproutHackathon.Services.Interfaces;

namespace SproutHackathon.Services.Helpers
{
    public class ApiRequestHelper
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public ApiRequestHelper(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        public async Task<HttpRequestMessage> CreateAuthorizedRequest(HttpMethod method, string relativeUrl)
        {
            var token = await _authRepository.GetAccessTokenAsync();
            var fullUrl = $"{_config["PartnerApi:ApiBaseUrl"]}/{relativeUrl}";

            var request = new HttpRequestMessage(method, fullUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("TenantCode", _config["PartnerApi:TenantCode"]);

            return request;
        }
    }
}
