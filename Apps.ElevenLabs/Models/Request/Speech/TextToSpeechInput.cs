using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

namespace Apps.ElevenLabs.Models.Request.Speech;

public class TextToSpeechInput
{
    [Display("Model ID")]
    [DataSource(typeof(ModelDataHandler))]
    public string ModelId { get; set; }
    
    public string? Text { get; set; }
    
    public FileReference? File { get; set; }

    [Display("Language code")]
    [StaticDataSource(typeof(LanguageDataHandler))]
    public string? LanguageCode { get; set; }

    [Display("Stability")]
    public double? Stability { get; set; }

    [Display("Similarity boost")]
    public double? SimilarityBoost { get; set; }

    [Display("Use speaker boost")]
    public bool? UseSpeakerBoost { get; set; }

    [Display("Style")]
    public double? Style { get; set; }

    [Display("Speed")]
    public double? Speed { get; set; }

    [Display("Pronunciation dictionary IDs")]
    [DataSource(typeof(PronunciationDictionariesDataHandler))]
    public List<string>? PronunciationDictionaryIds { get; set; }

    [Display("Pronunciation dictionary version IDs")]
    public List<string>? PronunciationDictionaryVersionIds { get; set; }

    [Display("Apply text normalization")]
    [StaticDataSource(typeof(TextNormalizationDataHandler))]
    public string? ApplyTextNormalization { get; set; }

    [Display("Apply language text normalization")]
    public bool? ApplyLanguageTextNormalization { get; set; }
}
