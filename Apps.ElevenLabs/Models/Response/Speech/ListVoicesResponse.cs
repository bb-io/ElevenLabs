using Apps.ElevenLabs.Models.Entities;

namespace Apps.ElevenLabs.Models.Response.Speech;

public class ListVoicesResponse
{
    public IEnumerable<VoiceEntity> Voices { get; set; }
}