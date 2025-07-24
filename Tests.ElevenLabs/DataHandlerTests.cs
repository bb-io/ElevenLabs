using Apps.ElevenLabs.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.ElevenLabs.Base;

namespace Tests.ElevenLabs
{
    [TestClass]
    public class DataHandlerTests :TestBase
    {
        [TestMethod]
        public async Task PronunciationDictionariesDataHandler_IsSuccess()
        {
            var dataHandler = new PronunciationDictionariesDataHandler(InvocationContext);
            var response = await dataHandler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
                SearchString = ""
            }, CancellationToken.None);

            foreach (var dictionary in response)
            {
                Console.WriteLine($"{dictionary.Key} - {dictionary.Value}");
            }

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task VoiceDataHandler_IsSuccess()
        {
            var dataHandler = new VoiceDataHandler(InvocationContext);
            var response = await dataHandler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
                SearchString = ""
            }, CancellationToken.None);

            foreach (var dictionary in response)
            {
                Console.WriteLine($"{dictionary.Key} - {dictionary.Value}");
            }

            Assert.IsNotNull(response);
        }


        [TestMethod]
        public async Task ModelDataHandler_IsSuccess()
        {
            var dataHandler = new ModelDataHandler(InvocationContext);
            var response = await dataHandler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
                SearchString = ""
            }, CancellationToken.None);

            foreach (var dictionary in response)
            {
                Console.WriteLine($"{dictionary.Key} - {dictionary.Value}");
            }

            Assert.IsNotNull(response);
        }
    }
}
