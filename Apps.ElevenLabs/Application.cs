using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.ElevenLabs;

public class Application : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Multimedia];
        set { }
    }
    
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