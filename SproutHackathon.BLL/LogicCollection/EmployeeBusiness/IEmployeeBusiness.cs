using SproutHackathon.BLL.DTOs;

namespace SproutHackathon.BLL.LogicCollection.EmployeeBusiness
{
    public interface IEmployeeBusiness
    {
        Task<EmployeeDto> GetEmployeeAsync(int id);
    }
}