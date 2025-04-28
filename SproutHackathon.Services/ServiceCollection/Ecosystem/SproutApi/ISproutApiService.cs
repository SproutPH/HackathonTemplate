using SproutHackathon.Services.Models.Company;
using SproutHackathon.Services.Models.Shared;

namespace SproutHackathon.Services.ServiceCollection.Ecosystem.SproutApi
{
    public interface ISproutApiService
    {
        Task<ResultWrapper<PagedResultOutput<CompanyOuput>>> GetCompaniesAsync(string token, InputWrapper<CompanyInput> input);
    }
}
