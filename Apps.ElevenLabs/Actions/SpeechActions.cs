using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Constants;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models.Request;
using Apps.ElevenLabs.Models.Request.Speech;
using Apps.ElevenLabs.Models.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.ElevenLabs.Actions;

[ActionList]
public class SpeechActions : ElevenLabsInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public SpeechActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Convert text to speech", Description = "Convert provided text to a speech with selected settings")]
    public async Task<FileResponse> TextToSpeech([ActionParameter] VoiceRequest voice,
        [ActionParameter] TextToSpeechInput input)
    {
        if ((input.Text is null && input.File is null) || (input.Text is not null && input.File is not null))
        {
            throw new("You should provide one input: Text or File");
        }

        var text = input.File is not null ? await GetFileText(input.File) : input.Text!;

        var endpoint = $"text-to-speech/{voice.VoiceId}";
        var request = new ElevenLabsRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new TextToSpeechRequest(input, text), JsonConfig.Settings);

        var response = await Client.ExecuteWithErrorHandling(request);

        return new()
        {
            File = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), "audio/mpeg",
                $"{voice.VoiceId}.mp3")
        };
    }

    [Action("Convert speech to speech", Description = "Convert provided speech to a speech with selected settings")]
    public async Task<FileResponse> SpeechToSpeech([ActionParameter] VoiceRequest voice, [ActionParameter] FileRequest file,
        [ActionParameter] StsModelRequest stsModel)
    {
        var endpoint = $"speech-to-speech/{voice.VoiceId}";
        var request = new ElevenLabsRequest(endpoint, Method.Post, Creds);

        var fileStream = await _fileManagementClient.DownloadAsync(file.File);
       
        request.AddParameter("model_id", stsModel.ModelId);
        request.AddFile("audio", () => fileStream, file.File.Name);
        request.AlwaysMultipartFormData = true;

        var response = await Client.ExecuteWithErrorHandling(request);
        
        return new()
        {
            File = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), "audio/mpeg",
                $"{voice.VoiceId}.mp3")
        };
    }

    private async Task<string> GetFileText(FileReference file)
    {
        var stream = await _fileManagementClient.DownloadAsync(file);
        return await new StreamReader(stream).ReadToEndAsync();
    }
}