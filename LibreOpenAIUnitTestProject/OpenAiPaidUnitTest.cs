using LibreOpenAI.DAL;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiPaidUnitTest : OpenAiUnitTestBase
    {
        /* 
#if DEBUG
        #region Create

        //// NOTE: this test is only when your API Key doesn't have money
        //[TestMethod]
        //public async Task Create_ADynmicResquestWithMaxCompletionTokensExceded_ThrowsLibreOpenAITooManyRequestsException()
        //{

        //    dynamic request = new
        //    {
        //        model = defaultModel,
        //        max_completion_tokens = defaultMaxCompletionTokens,
        //        messages = new [] {
        //            new {
        //                role = defaultRole,
        //                content = new [] { ResponseFakes.whatIsTheCapitalOfFrance }
        //            }
        //        }
        //    };
        //    IOpenAI sut = new OpenAI();

        //    try
        //    {
        //        IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

        //        Assert.IsTrue(false, "An Exception was expected.");
        //    }
        //    catch (LibreOpenAITooManyRequestsException ex)
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
        //    }
        //}

        [TestMethod]
        public async Task Create_AJsonRequestWithFunctions_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.functionsResquest);
            string jsonRequest = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(jsonRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(RequestFakes.weatherFunctionName, result.Choices.First().Message.ToolCalls.First().Function.Name);
        }

        [TestMethod]
        public async Task CreateDynamic_WithLogprobsEqualsTrue_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.logprobsResquest);
            IOpenAI sut = new OpenAI();
        
            IDictionary<string, object> result = await sut.Chat.Completions.CreateDynamic(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IList<object>)result["choices"]).Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(
                ((IDictionary<string, object>)
                    ((IDictionary<string, object>)
                        ((IList<object>)result["choices"])[0])["message"])["content"].ToString()));
        }

        [TestMethod]
        public async Task CreateDynamic_WithImageInputResquest_CallsOpenAiApiAndReturnsDynamic()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.imageInputResquest);
            IOpenAI sut = new OpenAI();
        
            IDictionary<string, object> result = await sut.Chat.Completions.CreateDynamic(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IList<object>)result["choices"]).Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(
                ((IDictionary<string, object>)
                    ((IDictionary<string, object>)
                        ((IList<object>)result["choices"])[0])["message"])["content"].ToString()));
        }

        [TestMethod]
        public async Task CreateDynamic_AJsonRequestWithDefaultRequest_CallsOpenAiApiAndReturnsDynamic()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.defaultResquest);
            string jsonRequest = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = new OpenAI();
        
            IDictionary<string, object> result = await sut.Chat.Completions.CreateDynamic(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((IList<object>)result["choices"]).Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(
                ((IDictionary<string, object>)
                    ((IDictionary<string, object>)
                        ((IList<object>)result["choices"])[0])["message"])["content"].ToString()));
        }

        [TestMethod]
        public async Task CreateJson_WithJsonRequestParam_ReturnsWhatIsTheCapitalofFranceAsJson()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = new OpenAI();

            string jsonResult = await sut.Chat.Completions.CreateJson(request);
            IChatCompletionResponse result = JsonConvert.DeserializeObject<ChatCompletionResponse>(jsonResult);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsTrue(result.Choices.First().Message.Content.Contains("Paris"));
        }

        [TestMethod]
        public async Task Create_WithDynamicRequestParam_ReturnsWhatIsTheCapitalofFranceAsJson()
        {
            dynamic request = new {
                model = defaultModel,
                max_completion_tokens = defaultMaxCompletionTokens,
                messages = new[] {
                    new {
                        role = defaultRole,
                        content = ResponseFakes.whatIsTheCapitalOfFrance
                    }
                }
            };
            IOpenAI sut = new OpenAI();

            string jsonResult = await sut.Chat.Completions.CreateJson(request);
            IChatCompletionResponse result = JsonConvert.DeserializeObject<ChatCompletionResponse>(jsonResult);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsTrue(result.Choices.First().Message.Content.Contains("Paris"));
        }

        #endregion

        #region CreateStream

        [TestMethod]
        public async Task CreateStream_WithStreamingEqualsTrue_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.streamingResquest);
            IOpenAI sut = new OpenAI();

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).Any(content => !string.IsNullOrWhiteSpace(content)));
        }

        [TestMethod]
        public async Task CreateStream_AJsonRequestWithStreamingEqualsTrueAndJsonRequestParam_CallsOpenAiApi()
        {
            string request = RequestFakes.streamingResquest;
            IOpenAI sut = new OpenAI();

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).Any(content => !string.IsNullOrWhiteSpace(content)));
        }

        [TestMethod]
        public async Task CreateStream_ADynamicRequestWithStreamingEqualsTrueAndDynamicRequestParam_CallsOpenAiApi()
        {
            dynamic request = new
            {
                model = "gpt-4o",
                messages = new[]
                    {
                        new { role = "system", content = "You are a helpful assistant." },
                        new { role = "user", content = "Hello!" }
                    },
                stream = true
            };
            IOpenAI sut = new OpenAI();

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).Any(content => !string.IsNullOrWhiteSpace(content)));
        }

        #endregion
#endif
        // */
    }
}
