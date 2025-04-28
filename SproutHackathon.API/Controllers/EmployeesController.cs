using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SproutHackathon.Business.LogicCollection.EmployeeBusiness;

namespace SproutHackathon.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeBusiness.GetEmployeeAsync(id);
            return Ok(employee);
        }
    }
}