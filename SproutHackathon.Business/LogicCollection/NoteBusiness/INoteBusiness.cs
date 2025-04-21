using SproutHackathon.DataAccess.Entities;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness
{
    public interface INoteBusiness
    {
        Task<IEnumerable<NoteEntity>> GetAllAsync();
        Task<NoteEntity> AddAsync(NoteEntity note);
    }
}