using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Constants;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models;
using Apps.ElevenLabs.Models.Request.Dub;
using Apps.ElevenLabs.Models.Response.Dub;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.Actions
{
    [ActionList]
    public class DubbingActions : ElevenLabsInvocable
    {
        private readonly IFileManagementClient _fileManagementClient;

        public DubbingActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
            invocationContext)
        {
            _fileManagementClient = fileManagementClient;
        }

        [Action("Create a dub", Description ="Creates a dub to a video or audio file")]
        public async Task<CreateDubResponse> CreateDub([ActionParameter] CreateDubRequest input)
        {
            var request = new ElevenLabsRequest("/dubbing", Method.Post, Creds)
            {
                AlwaysMultipartFormData = true
            };

            if (input.File != null)
            {
                var fileStream = await _fileManagementClient.DownloadAsync(input.File);
                var mime = input.File.ContentType ?? DetectMime(input.File.Name);
                request.AddFile("file", () => fileStream, input.File.Name, mime);
            }

            if (input.CsvFile != null)
            {
                var csvStream = await _fileManagementClient.DownloadAsync(input.CsvFile);
                request.AddFile("csv_file", () => csvStream, input.CsvFile.Name, "text/csv");

                if (input.ForegroundAudio != null)
                {
                    var fg = await _fileManagementClient.DownloadAsync(input.ForegroundAudio);
                    request.AddFile("foreground_audio_file", () => fg, input.ForegroundAudio.Name, input.ForegroundAudio.ContentType);
                }
                if (input.BackgroundAudio != null)
                {
                    var bg = await _fileManagementClient.DownloadAsync(input.BackgroundAudio);
                    request.AddFile("background_audio_file", () => bg, input.BackgroundAudio.Name, input.BackgroundAudio.ContentType);
                }
            }

            if (!string.IsNullOrWhiteSpace(input.Name))
                request.AddParameter("name", input.Name);
            if (!string.IsNullOrWhiteSpace(input.SourceUrl))
                request.AddParameter("source_url", input.SourceUrl);
            if (!string.IsNullOrWhiteSpace(input.SourceLang))
                request.AddParameter("source_lang", input.SourceLang);
            if (!string.IsNullOrWhiteSpace(input.TargetLang))
                request.AddParameter("target_lang", input.TargetLang);

            if (input.NumSpeakers.HasValue)
                request.AddParameter("num_speakers", input.NumSpeakers.Value);
            if (input.Watermark.HasValue)
                request.AddParameter("watermark", input.Watermark.Value);

            if (input.StartTime.HasValue)
                request.AddParameter("start_time", input.StartTime.Value);
            if (input.EndTime.HasValue)
                request.AddParameter("end_time", input.EndTime.Value);

            if (input.HighestResolution.HasValue)
                request.AddParameter("highest_resolution", input.HighestResolution.Value);
            if (input.DropBackgroundAudio.HasValue)
                request.AddParameter("drop_background_audio", input.DropBackgroundAudio.Value);

            var response = await Client.ExecuteWithErrorHandling<CreateDubResponse>(request);
            return response;
        }


        [Action("Get dubbing details", Description ="Gets dubbing details")]
        public async Task<DubbingResponse> GetDubDetails([ActionParameter] DubbingRequest input)
        {
            var request = new ElevenLabsRequest($"/dubbing/{input.DubId}", Method.Get, Creds);
            var response = await Client.ExecuteWithErrorHandling<DubbingResponse>(request);

            return response;
        }

        [Action("Download dubbed transcript", Description = "Downloads dubbed transcript")]
        public async Task<FileModel> GetDubbingTransript([ActionParameter] DubbingRequest input,
            [ActionParameter] DubbingOptionsRequest options)
        {
            string lang = options.LanguageCode ?? null;
            if (string.IsNullOrWhiteSpace(lang))
            {
                var detailsReq = new ElevenLabsRequest($"/dubbing/{input.DubId}", Method.Get, Creds);
                var details = await Client.ExecuteWithErrorHandling<DubbingResponse>(detailsReq);
                if (details.TargetLanguages == null || !details.TargetLanguages.Any())
                    throw new PluginApplicationException($"No target languages available for dub {input.DubId}");
                lang = details.TargetLanguages.First();
            }

            var path = $"/dubbing/{input.DubId}/transcript/{lang}";
            var req = new ElevenLabsRequest(path, Method.Get, Creds);

            if (!string.IsNullOrWhiteSpace(options.TranscriptionFormat))
            {
                req.AddParameter("format_type", options.TranscriptionFormat, ParameterType.QueryString);
            }

            var res = await Client.ExecuteWithErrorHandling(req);

            var contentType = res.ContentType ?? "text/vtt";
            var ext = options.TranscriptionFormat?.ToLower() switch
            {
                "srt" => "srt",
                "vtt" => "vtt",
                _ => contentType.Contains("srt") ? "srt" : "vtt"
            };

            var ms = new MemoryStream(res.RawBytes);
            var fileName = $"transcript_{input.DubId}_{lang}.{ext}";
            var fileRef = await _fileManagementClient.UploadAsync(ms, contentType, fileName);

            return new FileModel { File = fileRef };
        }


        [Action("Download dubbed file", Description = "Downloads the dubbed audio or video file")]
        public async Task<FileModel> DownloadDubFile(
           [ActionParameter] DubbingRequest input,
           [ActionParameter] DubbingOptionsRequest options)
        {
            var lang = options.LanguageCode;
            if (string.IsNullOrWhiteSpace(lang))
            {
                var detailsReq = new ElevenLabsRequest($"/dubbing/{input.DubId}", Method.Get, Creds);
                var details = await Client.ExecuteWithErrorHandling<DubbingResponse>(detailsReq);
                if (details.TargetLanguages == null || !details.TargetLanguages.Any())
                    throw new PluginApplicationException($"No target languages available for dub {input.DubId}");
                lang = details.TargetLanguages.First();
            }

            var req = new ElevenLabsRequest($"/dubbing/{input.DubId}/audio/{lang}", Method.Get, Creds);
            var res = await Client.ExecuteWithErrorHandling(req);

            var contentType = res.ContentType ?? "application/octet-stream";
            var ext = contentType.Contains("mpeg") || contentType.Contains("mp3")
                ? "mp3"
                : contentType.Contains("mp4")
                    ? "MP4"
                    : "bin";

            using var ms = new MemoryStream(res.RawBytes);
            var fileName = $"dub_{input.DubId}_{lang}.{ext}";
            var fileRef = await _fileManagementClient.UploadAsync(ms, contentType, fileName);

            return new FileModel { File = fileRef };
        }

        private string DetectMime(string fileName) =>
            Path.GetExtension(fileName).ToLower() switch
            {
                ".mp4" => "video/mp4",
                ".wav" => "audio/wav",
                ".mp3" => "audio/mpeg",
                ".mov" => "video/quicktime",
                _ => "application/octet-stream"
            };}
}
