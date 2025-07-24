using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models.Request.Speech;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.ElevenLabs.DataSourceHandlers
{
    public class PronunciationDictionariesDataHandler : ElevenLabsInvocable, IAsyncDataSourceHandler
    {
        public PronunciationDictionariesDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
            CancellationToken cancellationToken)
        {
            var request = new ElevenLabsRequest("/pronunciation-dictionaries", Method.Get, Creds);
            var response = await Client.ExecuteWithErrorHandling<PronunciationDictionariesResponse>(request);

            return response.PronunciationDictionaries
               .Where(x => context.SearchString == null ||
                          x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
               .ToDictionary(x => x.Id, x => x.Name);
        }
    }
}