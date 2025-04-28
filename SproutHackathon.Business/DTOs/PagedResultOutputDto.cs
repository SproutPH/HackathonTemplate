namespace SproutHackathon.Business.DTOs
{
    public class PagedResultOutputDto<T>
    {
        public List<T> Data { get; set; }
        public PaginationOutputDto Pagination { get; set; }
    }
}
