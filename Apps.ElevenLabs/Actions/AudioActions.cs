using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Constants;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models;
using Apps.ElevenLabs.Models.Request.Audio;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.ElevenLabs.Actions;

public class AudioActions : ElevenLabsInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public AudioActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Generate sound", Description = "Generate a sound from the provided text")]
    public async Task<FileModel> GenerateAudio([ActionParameter] GenerateSoundRequest input)
    {
        var request = new ElevenLabsRequest("sound-generation", Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.Settings);

        var response = await Client.ExecuteWithErrorHandling(request);

        return new()
        {
            File = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), "audio/mpeg",
                $"sound-{DateTime.Now.Ticks}.mp3")
        };
    }

    [Action("Isolate audio", Description = "Remove background noise from audio")]
    public async Task<FileModel> IsolateAudio([ActionParameter] FileModel input)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(input.File);

        var request = new ElevenLabsRequest("audio-isolation", Method.Post, Creds)
            .AddFile("audio", () => fileStream, input.File.Name);
        request.AlwaysMultipartFormData = true;

        var response = await Client.ExecuteWithErrorHandling(request);

        return new()
        {
            File = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), "audio/mpeg",
                input.File.Name)
        };
    }
}