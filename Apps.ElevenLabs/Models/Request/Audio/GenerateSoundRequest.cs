using Blackbird.Applications.Sdk.Common;

namespace Apps.ElevenLabs.Models.Request.Audio;

public class GenerateSoundRequest
{
    public string Text { get; set; }
    
    [Display("Duration seconds")]
    public int? DurationSeconds { get; set; }
    
    [Display("Prompt influence")]
    public int? PromptInfluence { get; set; }
}