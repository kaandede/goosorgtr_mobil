using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class ListedResult<T>
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("items")]
        public List<T> Items { get; set; }
    }
}
