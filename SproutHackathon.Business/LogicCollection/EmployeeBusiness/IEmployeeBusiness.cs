using SproutHackathon.Business.DTOs;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness
{
    public interface IEmployeeBusiness
    {
        Task<EmployeeDto> GetEmployeeAsync(int id);
    }
}