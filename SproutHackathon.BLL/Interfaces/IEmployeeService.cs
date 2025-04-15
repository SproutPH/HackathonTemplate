using SproutHackathon.BLL.DTOs;

namespace SproutHackathon.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeAsync(int id);
    }
}