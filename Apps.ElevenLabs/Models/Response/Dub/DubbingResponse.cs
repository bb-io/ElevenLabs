using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.Models.Response.Dub
{
    public class DubbingResponse
    {
        [JsonProperty("dubbing_id")]
        [Display("Dubbing ID")]
        public string DubbingId { get; set; }

        [JsonProperty("name")]
        [Display("Name")]
        public string? Name { get; set; }

        [JsonProperty("status")]
        [Display("Status")]
        public string Status { get; set; }

        [JsonProperty("target_languages")]
        [Display("Target Languages")]
        public List<string> TargetLanguages { get; set; } = new();

        [JsonProperty("media_metadata")]
        [Display("Media metadata")]
        public MediaMetadata MediaMetadata { get; set; }

        [JsonProperty("error")]
        [Display("Error")]
        public string? Error { get; set; }
    }

    public class MediaMetadata
    {
        [JsonProperty("content_type")]
        [Display("Content type")]
        public string ContentType { get; set; }

        [JsonProperty("duration")]
        [Display("Duration")]
        public double Duration { get; set; }
    }
}
