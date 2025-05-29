using Apps.ElevenLabs.Api;
using Apps.ElevenLabs.Invocables;
using Apps.ElevenLabs.Models.Request.Dub;
using Apps.ElevenLabs.Models.Response.Dub;
using Apps.ElevenLabs.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ElevenLabs.Webhooks
{
    [PollingEventList]
    public class PollingList : ElevenLabsInvocable
    {
        public PollingList(InvocationContext invocationContext) : base(invocationContext)
        {
        }


        [PollingEvent("On dubbing completed", Description = "Triggers when a dubbing job reaches status completed")]
        public async Task<PollingEventResponse<DateMemory,DubbingResponse>> OnDubbibgCompleted(
             PollingEventRequest<DateMemory> request,
             [PollingEventParameter] DubbingRequest dub)
        {
            var detailsReq = new ElevenLabsRequest($"/dubbing/{dub.DubId}", Method.Get, Creds);
            var details = await Client.ExecuteWithErrorHandling<DubbingResponse>(detailsReq);

            if (request.Memory == null)
            {
                return new PollingEventResponse<DateMemory, DubbingResponse>
                {
                    FlyBird = false,
                    Memory = new DateMemory
                    {
                        LastInteractionDate = DateTime.UtcNow,
                        LastStatus = details.Status
                    }
                };
            }

            var memory = request.Memory;

            if (!string.Equals(memory.LastStatus, "dubbed", StringComparison.OrdinalIgnoreCase)
                && string.Equals(details.Status, "dubbed", StringComparison.OrdinalIgnoreCase))
            {
                memory.LastStatus = details.Status;
                memory.LastInteractionDate = DateTime.UtcNow;

                return new PollingEventResponse<DateMemory, DubbingResponse>
                {
                    FlyBird = true,
                    Memory = memory,
                    Result = details
                };
            }

            memory.LastStatus = details.Status;
            return new PollingEventResponse<DateMemory, DubbingResponse>
            {
                FlyBird = false,
                Memory = memory
            };
        }

    }
}
