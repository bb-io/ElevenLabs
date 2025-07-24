using Apps.ElevenLabs.Actions;
using Apps.ElevenLabs.Models.Request.Dub;
using Apps.ElevenLabs.Models.Request.Speech;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.ElevenLabs.Base;

namespace Tests.ElevenLabs
{
    [TestClass]
    public class DubbingTests : TestBase
    {
        [TestMethod]
        public async Task CreateDub_IsSuccess()
        {
            var action = new DubbingActions(InvocationContext, FileManager);

            var response = await action.CreateDub(new CreateDubRequest{
                Name = "Test Dub from local call",
                File= new FileReference { Name= "test.MP4" },
                SourceLang = "en",
                TargetLang = "es",
            });

            Console.WriteLine($"{response.Id} - {response.ExpectedDurationSec}");

            Assert.IsNotNull(response);
        }


        [TestMethod]
        public async Task GetDub_IsSuccess()
        {
            var action = new DubbingActions(InvocationContext, FileManager);

            var response = await action.GetDubDetails(new DubbingRequest { DubId= "f2pZOuTcA4eTDuMmEOxU" });

            Console.WriteLine($"{response.DubbingId} - {response.Name}");

            var resultJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(resultJson);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task DownloadTranscripts_IsSuccess()
        {
            var action = new DubbingActions(InvocationContext, FileManager);

            var response = await action.GetDubbingTransript(new DubbingRequest { DubId = "f2pZOuTcA4eTDuMmEOxU" },
                new DubbingOptionsRequest { TranscriptionFormat="srt" });

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task DownloadDubbedFile_IsSuccess()
        {
            var action = new DubbingActions(InvocationContext, FileManager);

            var response = await action.DownloadDubFile(new DubbingRequest { DubId = "f2pZOuTcA4eTDuMmEOxU" },
                new DubbingOptionsRequest { });

            Assert.IsNotNull(response);
        }


        [TestMethod]
        public async Task ConvertTextToSpeach_IsSuccess()
        {
            var action = new SpeechActions(InvocationContext, FileManager);

            var response = await action.TextToSpeech(new VoiceRequest { VoiceId = "EXAVITQu4vr4xnSDxMaL" },
                new TextToSpeechInput { Text="Hello my dear friend how are you?",
                LanguageCode = "en",
                Stability =0.6,
                UseSpeakerBoost=true,
                SimilarityBoost=1,
                ModelId= "eleven_flash_v2_5",
                Style=1,
                Speed=1.2,
                ApplyTextNormalization="auto",
                //ApplyLanguageTextNormalization = true
                });

        
            var resultJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(resultJson);

            Assert.IsNotNull(response);
        }
    }
}
