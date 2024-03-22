using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ElevenLabs.DataSourceHandlers;

/// <summary>
/// Speech to Speech model data source handler
/// </summary>
public class StsModelDataHandler : ElevenLabsInvocable, IAsyncDataSourceHandler
{
    public StsModelDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new ElevenLabsRequest("models", Method.Get, Creds);
        var items = await Client.ExecuteWithErrorHandling<IEnumerable<ModelEntity>>(request);

        return items
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Where(x => x.CanDoVoiceConversion)
            .ToDictionary(x => x.ModelId, x => x.Name);
    }
}