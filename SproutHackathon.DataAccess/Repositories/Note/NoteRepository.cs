using Microsoft.EntityFrameworkCore;
using SproutHackathon.DataAccess.Contexts;
using SproutHackathon.DataAccess.Entities;

namespace SproutHackathon.DataAccess.Repositories.Note
{
    public class NoteRepository : INoteRepository
    {
        private readonly SproutDbContext _context;

        public NoteRepository(SproutDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NoteEntity>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<NoteEntity?> GetByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<NoteEntity> AddAsync(NoteEntity note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }
    }
}