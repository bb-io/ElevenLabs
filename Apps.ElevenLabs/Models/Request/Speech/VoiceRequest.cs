using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ElevenLabs.Models.Request.Speech;

public class VoiceRequest
{
    [Display("Voice ID")]
    [DataSource(typeof(VoiceDataHandler))]
    public string VoiceId { get; set; }
}
