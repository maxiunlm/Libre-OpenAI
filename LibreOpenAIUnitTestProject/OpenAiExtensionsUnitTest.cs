using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Messages;

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
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens, request.MaxTokens);
            Assert.AreEqual(RequestBodyExtension.autoFunctionCall, (request.FunctionCall ?? string.Empty).ToString());
        }

        [TestMethod]
        public async Task OpenAiUnitTest_NoneFunctionCall()
        {
            IRequestBodyExtension request = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);
            request.FunctionCallString = RequestBodyExtension.noneFunctionCall;

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens, request.MaxTokens);
            Assert.AreEqual(RequestBodyExtension.noneFunctionCall, (request.FunctionCall ?? string.Empty).ToString());
        }

        [TestMethod]
        public async Task OpenAiUnitTest_ObjectFunctionCall()
        {
            IRequestBodyExtension request = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);
            IFunctionCallRequest functionCallObject = new FunctionCallRequest { Name = "FunctionCallRequest" };
            request.FunctionCallObject = functionCallObject;

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens, request.MaxTokens);
            Assert.AreSame(functionCallObject, request.FunctionCallObject);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_ListFunctionsRequest()
        {
            IRequestBodyExtension request = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);
            request.Functions = new List<FunctionsRequest>();
            FunctionsRequest funcReq = new FunctionsRequest
            {
                Name = "Name"
            };
            request.Functions.Add(funcReq);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens, request.MaxTokens);
            Assert.AreEqual(1, request.Functions.Count);
            Assert.AreSame(funcReq, request.Functions.First());
        }

        [TestMethod]
        public async Task OpenAiUnitTest_ListMessages()
        {
            IRequestBodyExtension request = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);
            request.MessagesExtension = new List<MessageRequestExtension>();
            MessageRequestExtension message = new MessageRequestExtension
            {
                Name = "Name",
                Role = MessageRequestExtension.functionRole,
                Content = new List<string> { string.Empty }
            };
            request.MessagesExtension.Add(message);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
            Assert.AreEqual(OpenAiUnitTestBase.defaultMaxCompletionTokens, request.MaxTokens);
            Assert.AreEqual(1, request.MessagesExtension.Count);
            Assert.AreSame(message, request.MessagesExtension.First());
        }
    }
}
