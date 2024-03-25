namespace Apps.ElevenLabs.Models.Request.Speech;

public class TextToSpeechRequest
{
    public string ModelId { get; set; }
    
    public string Text { get; set; }
    
    public TextToSpeechRequest(TextToSpeechInput input, string text)
    {
        ModelId = input.ModelId;
        Text = text;
    }
}