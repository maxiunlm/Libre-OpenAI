using LibreOpenAI.DAL;
using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Fakes;
using Moq;

namespace LibreOpenAI_UnitTestProject
{
    [TestClass]
    public class OpenAiUnitTest
    {
        private const string defaultRole = "user";
        private const string systemRole = "system";
        private const string defaultModel = "gpt-3.5-turbo";
        private const int noMaxCompletionTokens = 0;
        private const int defaultMaxCompletionTokens = 50;
        private const int aLotOfMaxCompletionTokens = 800;

        [TestMethod]
        public async Task OpenAiUnitTest_WhatIsTheCapitalofFrance()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_YouAreAHelpfulAssistante()
        {
            IRequestBody request = GetRequest(ResponseFakes.youAreAHelpfulAssistant);
            IOpenAI sut = GetSut(ResponseFakes.youAreAHelpfulAssistantJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.helloThereHowMayIAssistYouToday, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_MultiChoiceRequestJson()
        {
            IRequestBody request = GetRequestWithTemperature(ResponseFakes.testForMultipleChoices);
            IOpenAI sut = GetSut(ResponseFakes.multiChoiceResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.testForMultipleChoicesResponseFirst, result.Choices.First().Message.Content);
            Assert.AreEqual(ResponseFakes.testForMultipleChoicesResponseSecond, result.Choices.Last().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_TruncatedResponseJson()
        {
            IRequestBody request = GetRequestWithTemperature(ResponseFakes.testTruncatedResponse);
            IOpenAI sut = GetSut(ResponseFakes.truncatedResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.thisResponseWasCutShort, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_LogprobsResponseJson()
        {
            IRequestBody request = GetRequestWithTemperatureAndLogprobs(ResponseFakes.testForLogprobsPresent);
            IOpenAI sut = GetSut(ResponseFakes.logprobsResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.hereIAResponseWithLogprobs, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_HighTokenUsageResponseJson()
        {
            IRequestBody request = GetRequestWithALotOfTokens(ResponseFakes.testHighTokenUsageResponse);
            IOpenAI sut = GetSut(ResponseFakes.highTokenUsageResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.hereIsALongResponseToTestHighTokenUsage, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_EmptyChoicesResponseJson()
        {
            IRequestBody request = GetRequestWithNoTokens(ResponseFakes.testEmptyChoicesResponse);
            IOpenAI sut = GetSut(ResponseFakes.emptyChoicesResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(noMaxCompletionTokens, result.Choices.Count);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_AStandardCompletionResponseFromChatGptJson()
        {
            IRequestBody request = GetRequest(ResponseFakes.testAStandardCompletionResponseFromChatGpt);
            IOpenAI sut = GetSut(ResponseFakes.aStandardCompletionResponseFromChatGptJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.aStandardCompletionResponseFromChat, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_LogprobsResponseWithTextOffsetJson()
        {
            IRequestBody request = GetRequestWithLogprobs(ResponseFakes.testLogprobsResponseWithTextOffset);
            IOpenAI sut = GetSut(ResponseFakes.logprobsResponseWithTextOffsetJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.logprobsResponseWithTextOffset, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_FunctionCallFinishReasonJson()
        {
            IRequestBody request = GetRequestWithLogprobsAndOffset(ResponseFakes.testFunctionCallFinishReasonSystem, ResponseFakes.testFunctionCallFinishReasonUser);
            IOpenAI sut = GetSut(ResponseFakes.functionCallFinishReasonJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.functionCallFinishReason, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_DetailedTokenUsageResponseJson()
        {
            IRequestBody request = GetRequestForTokenUsage(ResponseFakes.testDtailedTokenUsageResponseSystem, ResponseFakes.testDetailedTokenUsageResponseUser);
            IOpenAI sut = GetSut(ResponseFakes.detailedTokenUsageResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.detailedTokenUsageResponse, result.Choices.First().Message.Content);
        }

        private IOpenAI GetSut(string responseJson)
        {
            Mock<IHttpClientAi> httpClientAiMock = new Mock<IHttpClientAi>();
            HttpResponseMessage response = new HttpResponseMessage { Content = new StringContent(responseJson) };
            httpClientAiMock.Setup(o => o.PostAsync(It.IsAny<Uri>(), It.IsAny<StringContent>())).Returns(Task.FromResult(response));
            IOpenAiData openAiData = new OpenAiData { Client = httpClientAiMock.Object };
            IOpenAI sut = new OpenAI();
            sut.Chat.Completions.OpenAiData = openAiData;

            return sut;
        }

        private IRequestBody GetRequest(string contentMessage)
        {
            return new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<IMessageRequest> {
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { contentMessage }
                    }
                }
            };
        }

        private IRequestBody GetRequestWithNoTokens(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.MaxCompletionTokens = noMaxCompletionTokens;

            return result;
        }

        private IRequestBody GetRequestWithTemperature(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.Temperature = 0.7m;

            return result;
        }

        private IRequestBody GetRequestWithLogprobs(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.Logprobs = true;

            return result;
        }

        private IRequestBody GetRequestWithLogprobsAndOffset(string systemContentMessage, string userContentMessage)
        {
            IRequestBody result = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Temperature = 0.5m,
                TopP = 1,
                Stop = null,
                Messages = new List<IMessageRequest> {
                    new MessageRequest {
                        Role = systemRole,
                        Content = new List<string> { systemContentMessage }
                    },
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { userContentMessage }
                    }
                }
            };

            return result;
        }

        private IRequestBody GetRequestForTokenUsage(string systemContentMessage, string userContentMessage)
        {
            IRequestBody result = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = aLotOfMaxCompletionTokens,
                Logprobs = true,
                N = 1,
                Messages = new List<IMessageRequest> {
                    new MessageRequest {
                        Role = systemRole,
                        Content = new List<string> { systemContentMessage }
                    },
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { userContentMessage }
                    }
                }
            };

            return result;
        }

        private IRequestBody GetRequestWithTemperatureAndLogprobs(string contentMessage)
        {
            IRequestBody result = GetRequestWithTemperature(contentMessage);
            result.Logprobs = true;

            return result;
        }

        private IRequestBody GetRequestWithALotOfTokens(string contentMessage)
        {
            IRequestBody result = GetRequestWithTemperature(contentMessage);
            result.MaxCompletionTokens = aLotOfMaxCompletionTokens;

            return result;
        }
    }
}