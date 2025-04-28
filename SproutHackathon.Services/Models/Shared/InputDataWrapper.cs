using System.Text.Json.Serialization;

namespace SproutHackathon.Services.Models.Shared
{
    public class InputWrapper<T>
    {
        [JsonPropertyName("inputData")]
        public QueryParamsWrapper<T> InputData { get; set; }
    }
}