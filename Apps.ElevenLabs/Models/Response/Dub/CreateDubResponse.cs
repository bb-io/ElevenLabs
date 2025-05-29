using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.ElevenLabs.Models.Response.Dub
{
    public class CreateDubResponse
    {
        [JsonProperty("dubbing_id")]
        [Display("Dubbing id")]
        public string Id { get; set; }

        [Display("Expected duration in seconds")]
        [JsonProperty("expected_duration_sec")]
        public decimal ExpectedDurationSec { get; set; }
    }

}
