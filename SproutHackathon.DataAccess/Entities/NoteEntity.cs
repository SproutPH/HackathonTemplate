using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SproutHackathon.DataAccess.Entities
{
    [Table("notes")] // <- match exact lowercase name
    public class NoteEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("content")]
        public string? Content { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}