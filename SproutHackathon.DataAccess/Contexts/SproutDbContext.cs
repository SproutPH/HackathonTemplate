using Microsoft.EntityFrameworkCore;
using SproutHackathon.DataAccess.Entities;

namespace SproutHackathon.DataAccess.Contexts
{
    public class SproutDbContext : DbContext
    {
        public SproutDbContext(DbContextOptions<SproutDbContext> options) : base(options) { }

        public DbSet<NoteEntity> Notes { get; set; }
    }
}