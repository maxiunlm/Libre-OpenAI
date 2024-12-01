using LibreOpenAI.DAL;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.IO;
using System.Reflection;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiPaidUnitTest : OpenAiUnitTestBase
    {
        //* 
#if DEBUG

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_MaxTokensExceded()
        {
            //IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = new OpenAI();

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An Exception was expected.");
            }
            catch (LibreOpenAITooManyRequestsException ex)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiTest_WithFunctions_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.functionsResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(RequestFakes.weatherFunctionName, result.Choices.First().Message.ToolCalls.First().Function.Name);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithImageInputResquest_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.imageInputResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithLogprobsEqualsTrue_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.logprobsResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
            Assert.IsTrue(result.Choices.First().Logprobs.Content.Any());
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithStreamingEqualsTrue_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.streamingResquest);
            IOpenAI sut = new OpenAI();

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).Any(content => !string.IsNullOrWhiteSpace(content)));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithDefaultRequest_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.defaultResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithJsonRequestParam_WhatIsTheCapitalofFrance()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsTrue(result.Choices.First().Message.Content.Contains("Paris"));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithDynamicRequestParam_WhatIsTheCapitalofFrance()
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

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsTrue(result.Choices.First().Message.Content.Contains("Paris"));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithStreamingEqualsTrueAndJsonRequestParam_CallsOpenAiApi()
        {
            string request = RequestFakes.streamingResquest;
            IOpenAI sut = new OpenAI();

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).Any(content => !string.IsNullOrWhiteSpace(content)));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithStreamingEqualsTrueAndDynamicRequestParam_CallsOpenAiApi()
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
#endif
        // */
    }
}
