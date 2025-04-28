using SproutHackathon.Business.DTOs;
using SproutHackathon.Services.ServiceCollection.Ecosystem.SproutApi;
using SproutHackathon.Services.ServiceCollection.Sprout.EmployeeService;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeService _service;
        private readonly ISproutApiService _sproutApiService;

        public EmployeeBusiness(IEmployeeService service, ISproutApiService sproutApiService)
        {
            _service = service;
            _sproutApiService = sproutApiService;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            var employee = await _service.GetEmployeeAsync(id);
            return new EmployeeDto
            {
                EmployeeId = employee.BasicInformation.EmployeeId,
                FullName = $"{employee.BasicInformation.FirstName} {employee.BasicInformation.LastName}",
            };
        }
    }
}