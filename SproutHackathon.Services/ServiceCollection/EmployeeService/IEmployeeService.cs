using SproutHackathon.Services.Models;

namespace SproutHackathon.Services.ServiceCollection.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(int id);
    }
}