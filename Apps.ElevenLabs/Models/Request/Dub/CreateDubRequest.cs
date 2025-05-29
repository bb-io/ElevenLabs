using Apps.ElevenLabs.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.Models.Request.Dub
{
    public class CreateDubRequest
    {
        [JsonProperty("file")]
        [Display("File")]
        public FileReference? File { get; set; }

        [JsonProperty("csv_file")]
        [Display("CSV file")]
        public FileReference? CsvFile { get; set; }

        [JsonProperty("foreground_audio_file")]
        [Display("Foreground audio file")]
        public FileReference? ForegroundAudio { get; set; }

        [JsonProperty("background_audio_file")]
        [Display("Background audio file")]
        public FileReference? BackgroundAudio { get; set; }

        [JsonProperty("name")]
        [Display("Name")]
        public string? Name { get; set; }

        [JsonProperty("source_url")]
        [Display("Source URL")]
        public string? SourceUrl { get; set; }

        [JsonProperty("source_lang")]
        [Display("Source language")]
        [StaticDataSource(typeof(LanguageDataHandler))]
        public string? SourceLang { get; set; }

        [JsonProperty("target_lang")]
        [Display("Target language")]
        [StaticDataSource(typeof(LanguageDataHandler))]
        public string TargetLang { get; set; }

        [JsonProperty("num_speakers")]
        [Display("Number of speakers")]
        public int? NumSpeakers { get; set; } = 0;

        [JsonProperty("watermark")]
        [Display("Watermark")]
        public bool? Watermark { get; set; } = true;

        [JsonProperty("start_time")]
        [Display("Start time (seconds)")]
        public int? StartTime { get; set; }

        [JsonProperty("end_time")]
        [Display("End time (seconds)")]
        public int? EndTime { get; set; }

        [JsonProperty("highest_resolution")]
        [Display("Highest resolution")]
        public bool? HighestResolution { get; set; } = false;

        [JsonProperty("drop_background_audio")]
        [Display("Drop background audio")]
        public bool? DropBackgroundAudio { get; set; } = false;

        [JsonProperty("dubbing_studio")]
        [Display("Dubbing studio")]
        public bool? DubbingStudio { get; set; } = false;
    }
}
