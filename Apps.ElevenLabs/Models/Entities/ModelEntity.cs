namespace Apps.ElevenLabs.Models.Entities;

public class ModelEntity
{
    public string ModelId { get; set; }
    
    public string Name { get; set; }
    
    public bool CanDoTextToSpeech { get; set; }
    
    public bool CanDoVoiceConversion { get; set; }
}