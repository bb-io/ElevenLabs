using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ElevenLabs.Models.Request.Speech;

public class StsModelRequest
{
    [Display("Model ID")]
    [DataSource(typeof(StsModelDataHandler))]
    public string ModelId { get; set; }
}