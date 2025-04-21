namespace SproutHackathon.DataAccess.Entities
{
    public class NoteEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}