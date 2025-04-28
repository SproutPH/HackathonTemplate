using SproutHackathon.Business.DTOs;
using SproutHackathon.Business.LogicCollection.CompanyBusiness;
using SproutHackathon.Services.Models.Company;
using SproutHackathon.Services.Models.Shared;
using SproutHackathon.Services.ServiceCollection.Ecosystem.SproutApi;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness.CompanyBusiness;

public class CompanyBusiness : ICompanyBusiness
{
    private readonly ISproutApiService _sproutApiService;

    public CompanyBusiness(ISproutApiService sproutApiService)
    {
        _sproutApiService = sproutApiService;
    }

    public async Task<PagedResultOutputDto<CompanyDto>> GetCompaniesAsync(int id, string token, GetCompaniesInputDto input)
    {
        var companyInput = new CompanyInput() { PageNumber = input.PageNumber, RowsPerPage = input.RowsPerPage, StringColumn = input.StringColumn, StringOrder = input.StringOrder };

        var queryParam = new QueryParamsWrapper<CompanyInput>() { QueryParams = companyInput };

        var serviceResult = await _sproutApiService.GetCompaniesAsync(token, new InputWrapper<CompanyInput> { InputData = queryParam });

        var mappedCompanies = new PagedResultOutputDto<CompanyDto>
        {
            Data = serviceResult.Result.Data.Select(x => new CompanyDto
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                PerfProUrl = x.PerfProUrl, // or map it if available
                PayrollSyncDetails = new PayrollSyncDetailsDto
                {
                    IsConnected = x.PayrollSyncDetails?.IsConnected ?? false,
                    CompanyCode = x.PayrollSyncDetails?.CompanyCode
                },
                PayrollPieDatabase = x.PayrollPieDatabase
            }).ToList(),

            Pagination = new PaginationOutputDto
            {
                CurrentPage = serviceResult.Result.Pagination.CurrentPage,
                TotalPages = serviceResult.Result.Pagination.TotalPages,
                TotalItems = serviceResult.Result.Pagination.TotalItems,
                ItemsPerPage = serviceResult.Result.Pagination.ItemsPerPage,
                Links = new PaginationLinksDto
                {
                    Next = serviceResult.Result.Pagination.Links.Next,
                    Last = serviceResult.Result.Pagination.Links.Last
                }
            }
        };

        return mappedCompanies;
    }
}


