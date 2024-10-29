using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiExtensionsUnitTest : OpenAiUnitTestBase
    {
        [TestMethod]
        public async Task OpenAiUnitTest_WhatIsTheCapitalofFrance()
        {
            IRequestBodyExtension request = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens,request.MaxTokens);
        }
    }
}
