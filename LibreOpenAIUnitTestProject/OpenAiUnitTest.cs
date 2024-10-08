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
        private const string defaultModel = "gpt-3.5-turbo";
        private const int defaultMaxCompletionTokens = 50;

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
            IRequestBody request = GetRequestWithTemperature(ResponseFakes.multiChoiceResponseJson);
            IOpenAI sut = GetSut(ResponseFakes.multiChoiceResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.testForMultipleChoicesResponseFirst, result.Choices.First().Message.Content);
            Assert.AreEqual(ResponseFakes.testForMultipleChoicesResponseSecond, result.Choices.Last().Message.Content);
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

        private IRequestBody GetRequestWithTemperature(string contentMessage)
        {
            return new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Temperature = 0.7m,
                Messages = new List<IMessageRequest> {
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { contentMessage }
                    }
                }
            };
        }
    }
}