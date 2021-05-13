using Newtonsoft.Json;

namespace MarmolApp.Model
{
    public class EntityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string EntityName { get; set; }
    }
}
