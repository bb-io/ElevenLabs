using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.ElevenLabs.Models.Request.Dub
{
    public class DubbingOptionsRequest
    {
        [Display("Transcript format")]
        [StaticDataSource(typeof(CaptionFormatDataHandler))]
        public string? TranscriptionFormat { get; set; }


        [Display("Language code")]
        [StaticDataSource(typeof(LanguageDataHandler))]
        public string? LanguageCode { get; set; }
    }
}
