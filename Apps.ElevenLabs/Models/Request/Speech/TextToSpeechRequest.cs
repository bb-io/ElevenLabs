namespace Apps.ElevenLabs.Models.Request.Speech;

public class TextToSpeechRequest
{
    public string ModelId { get; set; }
    public string Text { get; set; }
    public string? TargetLang { get; set; }
    public object? VoiceSettings { get; set; }
    public List<object>? PronunciationDictionaryLocators { get; set; }
    public string? ApplyTextNormalization { get; set; }
    public bool? ApplyLanguageTextNormalization { get; set; }

    public TextToSpeechRequest(TextToSpeechInput input, string text)
    {
        ModelId = input.ModelId;
        Text = text;
        TargetLang = input.LanguageCode;
        if (input.Stability.HasValue || input.SimilarityBoost.HasValue || input.Style.HasValue ||
            input.UseSpeakerBoost.HasValue || input.Speed.HasValue)
        {
            VoiceSettings = new
            {
                stability = input.Stability,
                similarity_boost = input.SimilarityBoost,
                style = input.Style,
                use_speaker_boost = input.UseSpeakerBoost,
                speed = input.Speed
            };
        }

        if (input.PronunciationDictionaryIds != null && input.PronunciationDictionaryVersionIds != null
            && input.PronunciationDictionaryIds.Count > 0 &&
            input.PronunciationDictionaryIds.Count == input.PronunciationDictionaryVersionIds.Count)
        {
            PronunciationDictionaryLocators = input.PronunciationDictionaryIds
                .Zip(input.PronunciationDictionaryVersionIds, (id, version) => new
                {
                    pronunciation_dictionary_id = id,
                    version_id = version
                })
                .Cast<object>()
                .ToList();
        }

        ApplyTextNormalization = input.ApplyTextNormalization;
        ApplyLanguageTextNormalization = input.ApplyLanguageTextNormalization;
    }
}