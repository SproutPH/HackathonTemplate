using System.Text.Json.Serialization;

namespace SproutHackathon.Services.Models.Shared
{
    public class QueryParamsWrapper<T>
    {
        public QueryParamsWrapper()
        {
        }

        public QueryParamsWrapper(T queryParams)
        {
            QueryParams = queryParams;
        }
        
        [JsonPropertyName("queryParams")]
        public T QueryParams { get; set; }
    }
}