using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.ElevenLabs.DataSourceHandlers
{
    public class LanguageDataHandler : IStaticDataSourceItemHandler
    {
        public IEnumerable<DataSourceItem> GetData()
        {
            return new List<DataSourceItem>
            {
                new DataSourceItem("en", "English"),
                new DataSourceItem("ja", "Japanese"),
                new DataSourceItem("zh", "Chinese"),
                new DataSourceItem("de", "German"),
                new DataSourceItem("hi", "Hindi"),
                new DataSourceItem("fr", "French"),
                new DataSourceItem("ko", "Korean"),
                new DataSourceItem("pt", "Portuguese"),
                new DataSourceItem("it", "Italian"),
                new DataSourceItem("es", "Spanish"),
                new DataSourceItem("id", "Indonesian"),
                new DataSourceItem("nl", "Dutch"),
                new DataSourceItem("tr", "Turkish"),
                new DataSourceItem("fil", "Filipino"),
                new DataSourceItem("pl", "Polish"),
                new DataSourceItem("sv", "Swedish"),
                new DataSourceItem("bg", "Bulgarian"),
                new DataSourceItem("ro", "Romanian"),
                new DataSourceItem("ar", "Arabic"),
                new DataSourceItem("cs", "Czech"),
                new DataSourceItem("el", "Greek"),
                new DataSourceItem("fi", "Finnish"),
                new DataSourceItem("hr", "Croatian"),
                new DataSourceItem("ms", "Malay"),
                new DataSourceItem("sk", "Slovak"),
                new DataSourceItem("da", "Danish"),
                new DataSourceItem("ta", "Tamil"),
                new DataSourceItem("uk", "Ukrainian"),
                new DataSourceItem("ru", "Russian"),
                new DataSourceItem("hu", "Hungarian"),
                new DataSourceItem("no", "Norwegian"),
                new DataSourceItem("vi", "Vietnamese"),
            };
        }
    }
}
