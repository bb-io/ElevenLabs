using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.DataSourceHandlers
{
    public class CaptionFormatDataHandler : IStaticDataSourceItemHandler
    {
        public IEnumerable<DataSourceItem> GetData()
        {
            var conflictBehaviors = new List<DataSourceItem>()
        {
            new DataSourceItem("srt", "srt format"),
            new DataSourceItem("webvtt", "webvtt format")
        };
            return conflictBehaviors;
        }
    }
}