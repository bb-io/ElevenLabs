using Apps.ElevenLabs.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.ElevenLabs.Connections;

public class ConnectionValidator: IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        var request = new ElevenLabsRequest("models", Method.Get, authenticationCredentialsProviders);
        await new ElevenLabsClient().ExecuteWithErrorHandling(request);
        
        return new()
        {
            IsValid = true
        };
    }
}