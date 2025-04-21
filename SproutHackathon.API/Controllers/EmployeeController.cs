using Microsoft.AspNetCore.Mvc;
using SproutHackathon.BLL.DTOs;
using SproutHackathon.BLL.LogicCollection.EmployeeBusiness;

namespace SproutHackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _employeeBusiness.GetEmployeeAsync(id);
            return Ok(employee);
        }
    }
}