using SproutHackathon.DataAccess.Entities;
using SproutHackathon.DataAccess.Repositories.Note;

namespace SproutHackathon.Business.LogicCollection.EmployeeBusiness
{
    public class NoteBusiness: INoteBusiness
    {
        private readonly INoteRepository _repo;

        public NoteBusiness(INoteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<NoteEntity>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<NoteEntity> AddAsync(NoteEntity note)
        {
            return await _repo.AddAsync(note);
        }
    }
}