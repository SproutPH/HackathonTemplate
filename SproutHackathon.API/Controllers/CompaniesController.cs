using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SproutHackathon.Business.DTOs;
using SproutHackathon.Business.LogicCollection.CompanyBusiness;

namespace SproutHackathon.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyBusiness _companyBusiness;

        public CompaniesController(ICompanyBusiness companyBusiness)
        {
            _companyBusiness = companyBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            int rowsPerPage = 10,
            int pageNumber = 1,
            string stringColumn = null,
            string stringOrder = null
        )
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var input = new GetCompaniesInputDto
            {
                RowsPerPage = rowsPerPage,
                PageNumber = pageNumber,
                StringColumn = stringColumn,
                StringOrder = stringOrder
            };

            var result = await _companyBusiness.GetCompaniesAsync(0, token, input);

            return Ok(result);
        }
    }
}