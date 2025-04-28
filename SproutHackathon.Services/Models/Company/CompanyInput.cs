using System.Text.Json.Serialization;

namespace SproutHackathon.Services.Models.Company
{
    public class CompanyInput
    {
        [JsonPropertyName("rowsPerPage")]
        public int RowsPerPage { get; set; }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("stringColumn")]
        public string StringColumn { get; set; }

        [JsonPropertyName("stringOrder")]
        public string StringOrder { get; set; }
    }
}