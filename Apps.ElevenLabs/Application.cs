using Blackbird.Applications.Sdk.Common;

namespace Apps.ElevenLabs;

public class Application : IApplication
{
    public string Name
    {
        get => "ElevenLabs";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}