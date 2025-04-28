namespace SproutHackathon.Services.Models.Shared
{
    public class PaginationOutput
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginationLinks Links { get; set; }
    }
    public class PaginationLinks
    {
        public string Next { get; set; }
        public string Last { get; set; }
    }
}
