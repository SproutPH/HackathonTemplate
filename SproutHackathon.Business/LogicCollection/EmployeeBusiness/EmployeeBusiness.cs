using SproutHackathon.Business.DTOs;
using SproutHackathon.Services.ServiceCollection.EmployeeService;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeService _service;

        public EmployeeBusiness(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            var employee = await _service.GetEmployeeAsync(id);
            return new EmployeeDto
            {
                EmployeeId = employee.basicInformation.employeeId,
                FullName = $"{employee.basicInformation.firstName} {employee.basicInformation.lastName}",
            };
        }
    }
}