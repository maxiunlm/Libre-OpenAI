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
            Mock<IHttpClientAi> httpClientAiMock = new Mock<IHttpClientAi>();
            HttpResponseMessage response = new HttpResponseMessage { Content = new StringContent (ResponseFakes.theCapitalOfFranceIsParisJson) };
            httpClientAiMock.Setup(o => o.PostAsync(It.IsAny<Uri>(), It.IsAny<StringContent>())).Returns(Task.FromResult(response));
            IOpenAiData openAiData = new OpenAiData { Client = httpClientAiMock.Object };
            IRequestBody request = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<IMessageRequest> {
                    new MessageRequest { 
                        Role = defaultRole,
                        Content = new List<string> { "What is the capilal of France?" }
                    } 
                }
            };
            IOpenAI sut = new OpenAI();
            sut.Chat.Completions.OpenAiData = openAiData;

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("The capital of France is Paris", result.Choices.First().Message.Content);
        }
    }
}