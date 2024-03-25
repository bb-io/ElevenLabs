using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.ElevenLabs.Models.Request.Speech;

public class TextToSpeechInput
{
    [Display("Model ID")]
    [DataSource(typeof(ModelDataHandler))]
    public string ModelId { get; set; }
    
    public string? Text { get; set; }
    
    public FileReference? File { get; set; }
}