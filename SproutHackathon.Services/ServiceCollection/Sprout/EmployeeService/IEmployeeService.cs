using SproutHackathon.Services.Models;

namespace SproutHackathon.Services.ServiceCollection.Sprout.EmployeeService
{
    public interface IEmployeeService
    {
        Task<EmployeeOutput> GetEmployeeAsync(int id);
    }
}