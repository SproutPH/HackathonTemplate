namespace SproutHackathon.Services.Models.Shared
{
    public class PagedResultOutput<T>
    {
        public List<T> Data { get; set; }
        public PaginationOutput Pagination { get; set; }
    }
}