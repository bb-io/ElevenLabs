using Apps.ElevenLabs.Models.Request.Dub;
using Apps.ElevenLabs.Webhooks;
using Apps.ElevenLabs.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Polling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.ElevenLabs.Base;

namespace Tests.ElevenLabs
{
    [TestClass]
    public class PollingTests : TestBase
    {
        [TestMethod]
        public async Task OnDubCompleted_IsSuccess()
        {
            var polling = new PollingList(InvocationContext);

            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow,
                    LastStatus = "processing"
                }
            };

            var response = await polling.OnDubbibgCompleted(
                request,
                new DubbingRequest
                {
                    DubId = "f2pZOuTcA4eTDuMmEOxU"
                });

            Assert.IsNotNull(response);
        }
    }
}
