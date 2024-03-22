using Apps.ElevenLabs.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.ElevenLabs.Api;

public class ElevenLabsRequest : BlackBirdRestRequest
{
    public ElevenLabsRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) :
        base(resource, method, creds)
    {
    }

    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        this.AddHeader("xi-api-key", creds.Get(CredsNames.ApiKey).Value);
    }
}