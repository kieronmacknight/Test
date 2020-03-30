using Newtonsoft.Json;

namespace Covid.WorkerService.Configuration
{
    [JsonObject("api")]
    public class Api
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rootUri")]
        public string RootUri { get; set; }
    }
}
