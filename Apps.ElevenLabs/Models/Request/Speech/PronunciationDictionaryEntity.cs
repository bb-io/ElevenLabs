using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.Models.Request.Speech
{
    public class PronunciationDictionaryEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("latest_version_id")]
        public string LatestVersionId { get; set; }

        [JsonProperty("latest_version_rules_num")]
        public int LatestVersionRulesNum { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permission_on_resource")]
        public string PermissionOnResource { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("creation_time_unix")]
        public long CreationTimeUnix { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class PronunciationDictionariesResponse
    {
        [JsonProperty("pronunciation_dictionaries")]
        public List<PronunciationDictionaryEntity> PronunciationDictionaries { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}
