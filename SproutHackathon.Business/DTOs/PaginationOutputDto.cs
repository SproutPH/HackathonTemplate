namespace SproutHackathon.Business.DTOs
{
    public class PaginationOutputDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginationLinksDto Links { get; set; }
    }
    public class PaginationLinksDto
    {
        public string Next { get; set; }
        public string Last { get; set; }
    }
}
