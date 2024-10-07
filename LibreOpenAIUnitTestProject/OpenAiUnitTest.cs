using LibreOpenAI.DAL;
using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Fakes;
using Moq;
using System.Net;
using System.Net.Http.Headers;

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
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_YouAreAHelpfulAssistante()
        {
            IRequestBody request = GetRequest(ResponseFakes.youAreAHelpfulAssistant);
            IOpenAI sut = GetSut(ResponseFakes.youAreAHelpfulAssistantJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseFakes.helloThereHowMayIAssistYouToday, result.Choices.First().Message.Content);
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
    }
}