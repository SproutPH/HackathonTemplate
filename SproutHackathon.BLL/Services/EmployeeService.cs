using SproutHackathon.BLL.DTOs;
using SproutHackathon.BLL.Interfaces;
using SproutHackathon.Services.Interfaces;

namespace SproutHackathon.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            var employee = await _repo.GetEmployeeAsync(id);
            return new EmployeeDto
            {
                EmployeeId = employee.basicInformation.employeeId,
                FullName = $"{employee.basicInformation.firstName} {employee.basicInformation.lastName}",
            };
        }
    }
}