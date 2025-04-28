using System.Net.Http.Json;
using SproutHackathon.Services.Helpers;
using SproutHackathon.Services.Models;

namespace SproutHackathon.Services.ServiceCollection.Sprout.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiRequestHelper _requestHelper;

        public EmployeeService(HttpClient httpClient, ApiRequestHelper requestHelper)
        {
            _httpClient = httpClient;
            _requestHelper = requestHelper;
        }

        public async Task<EmployeeOutput> GetEmployeeAsync(int id)
        {
            var request = await _requestHelper.CreateSproutAuthRequest(HttpMethod.Get, $"/e/api/v1/Employees/{id}");
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EmployeeOutput>();
        }
    }
}