using SproutHackathon.Services.Models;

namespace SproutHackathon.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeAsync(int id);
    }
}