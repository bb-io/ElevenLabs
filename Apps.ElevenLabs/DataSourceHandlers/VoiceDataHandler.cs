using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models.Response.Speech;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ElevenLabs.DataSourceHandlers;

public class VoiceDataHandler : ElevenLabsInvocable, IAsyncDataSourceHandler
{
    public VoiceDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new ElevenLabsRequest("voices", Method.Get, Creds);
        var items = await Client.ExecuteWithErrorHandling<ListVoicesResponse>(request);

        return items.Voices
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.VoiceId, x => x.Name);
    }
}