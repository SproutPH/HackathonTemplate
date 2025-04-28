namespace SproutHackathon.Business.DTOs
{
    public class GetCompaniesInputDto
    {
        public int RowsPerPage { get; set; }
        public int PageNumber { get; set; }
        public string StringColumn { get; set; }
        public string StringOrder { get; set; }
    }
}