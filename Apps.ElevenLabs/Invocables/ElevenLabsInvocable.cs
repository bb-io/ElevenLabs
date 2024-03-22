using Apps.ElevenLabs.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.ElevenLabs.Invocables;

public class ElevenLabsInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected ElevenLabsClient Client { get; }
    public ElevenLabsInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}