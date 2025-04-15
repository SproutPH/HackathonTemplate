using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SproutHackathon.Services.Interfaces;

namespace SproutHackathon.Services.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AuthRepository(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var form = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _config["Auth:ClientId"] },
                { "client_secret", _config["Auth:ClientSecret"] }
            };

            var content = new FormUrlEncodedContent(form);

            var request = new HttpRequestMessage(HttpMethod.Post, _config["Auth:TokenEndpoint"])
            {
                Content = content
            };

            // Optional: Add Content-Type explicitly (not usually needed, but OK)
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            using var json = JsonDocument.Parse(responseBody);
            return json.RootElement.GetProperty("access_token").GetString();
        }
    }
}
