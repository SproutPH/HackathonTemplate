using SproutHackathon.Business.DTOs;

namespace SproutHackathon.Business.LogicCollection.CompanyBusiness;

public interface ICompanyBusiness
{
    Task<PagedResultOutputDto<CompanyDto>> GetCompaniesAsync(int id, string token, GetCompaniesInputDto input);
}


