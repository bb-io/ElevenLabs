using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ElevenLabs.DataSourceHandlers
{
    public class TextNormalizationDataHandler : IStaticDataSourceItemHandler
    {
        public IEnumerable<DataSourceItem> GetData()
        {
            return new List<DataSourceItem>
            {
                new DataSourceItem("auto", "Auto - System decides text normalization"),
                new DataSourceItem("on", "On - Always apply text normalization"),
                new DataSourceItem("off", "Off - Skip text normalization")
            };
        }
    }
}
