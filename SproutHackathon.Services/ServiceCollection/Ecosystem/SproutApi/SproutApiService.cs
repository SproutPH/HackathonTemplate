using System.Net.Http.Json;
using SproutHackathon.Services.Helpers;
using SproutHackathon.Services.Models.Company;
using SproutHackathon.Services.Models.Shared;

namespace SproutHackathon.Services.ServiceCollection.Ecosystem.SproutApi
{

    public class SproutApiService : ISproutApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiRequestHelper _requestHelper;

        public SproutApiService(HttpClient httpClient, ApiRequestHelper requestHelper)
        {
            _httpClient = httpClient;
            _requestHelper = requestHelper;
        }

        public async Task<ResultWrapper<PagedResultOutput<CompanyOuput>>> GetCompaniesAsync(string token, InputWrapper<CompanyInput> input)
        {
            var request = await _requestHelper.CreateEcoAuthRequest(HttpMethod.Post, "8d8b8ffd-7a99-4349-926e-920fdd070b9b", token, input);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ResultWrapper<PagedResultOutput<CompanyOuput>>>();
        }
    }
}
