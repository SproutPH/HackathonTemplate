using SproutHackathon.DataAccess.Entities;

namespace SproutHackathon.DataAccess.Repositories.Note
{
    public interface INoteRepository
    {
        Task<IEnumerable<NoteEntity>> GetAllAsync();
        Task<NoteEntity?> GetByIdAsync(int id);
        Task<NoteEntity> AddAsync(NoteEntity note);
    }
}