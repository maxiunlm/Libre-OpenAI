using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi;
using LibreOpenAIUnitTestProject.Fakes;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAI.Exceptions.OpenAI;
using System.Net;
using Newtonsoft.Json;
using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiExceptionsUnitTest : OpenAiUnitTestBase
    {
        /* 
#if DEBUG

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_MaxTokensExceded()
        {
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

#endif
        // */

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_MaxTokensExceded_ThrowsLibreOpenAITooManyRequestsException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.TooManyRequests)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAITooManyRequestsException was expected.");
            }
            catch (LibreOpenAITooManyRequestsException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_HttpRequestException_ThrowsLibreOpenAiAuthenticationException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.Unauthorized)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiAuthenticationException was expected.");
            }
            catch (LibreOpenAiAuthenticationException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_HttpRequestException_ThrowsLibreOpenAiInternalServerErrorException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.InternalServerError)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiInternalServerErrorException was expected.");
            }
            catch (LibreOpenAiInternalServerErrorException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_HttpRequestException_ThrowsLibreOpenAiBadGatewayException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.BadGateway)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiBadGatewayException was expected.");
            }
            catch (LibreOpenAiBadGatewayException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_HttpRequestException_ThrowsLibreOpenAiServiceUnavailableException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.ServiceUnavailable)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiServiceUnavailableException was expected.");
            }
            catch (LibreOpenAiServiceUnavailableException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_HttpRequestException_ThrowsLibreOpenAiGatewayTimeoutException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new HttpRequestException(string.Empty, null, HttpStatusCode.GatewayTimeout)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiGatewayTimeoutException was expected.");
            }
            catch (LibreOpenAiGatewayTimeoutException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_JsonSerializationException_ThrowsLibreOpenAiJsonSerializationException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new JsonSerializationException(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiJsonSerializationException was expected.");
            }
            catch (LibreOpenAiJsonSerializationException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_JsonReaderException_ThrowsLibreOpenAiJsonReaderException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new JsonReaderException(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiJsonReaderException was expected.");
            }
            catch (LibreOpenAiJsonReaderException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_ArgumentException_ThrowsLibreOpenAiArgumentException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new ArgumentException(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiArgumentException was expected.");
            }
            catch (LibreOpenAiArgumentException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_TaskCanceledException_ThrowsLibreOpenAiTaskCanceledException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new TaskCanceledException(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiTaskCanceledException was expected.");
            }
            catch (LibreOpenAiTaskCanceledException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAITooManyRequestsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_OperationCanceledException_ThrowsLibreOpenAiOperationCanceledException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new OperationCanceledException(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiOperationCanceledException was expected.");
            }
            catch (LibreOpenAiOperationCanceledException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiOperationCanceledException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_UnexpectedException_ThrowsLibreOpenAiUnexpectedException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSutWichThrowsException(
                ResponseFakes.theCapitalOfFranceIsParisJson,
                new Exception(string.Empty)
            );

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "An LibreOpenAiUnexpectedException was expected.");
            }
            catch (LibreOpenAiUnexpectedException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiUnexpectedException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_InvaliedFunctionToolName_ThrowsLibreOpenAiNameRegexException()
        {
            IRequestBody sut = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.Tools = new List<ToolRequest>();
                sut.Tools.Add(new ToolRequest
                {
                    Type = ToolRequest.defaultType,
                    Function = new FunctionToolRequest
                    {
                        MustThrowNameRegexException = true,
                        Name = "$invelid Name!"
                    }
                });

                Assert.IsTrue(false, "An LibreOpenAiNameRegexException was expected.");
            }
            catch (LibreOpenAiNameRegexException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiNameRegexException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_DeprecatedInvaliedFunctionName_ThrowsLibreOpenAiNameRegexException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.Functions = new List<FunctionsRequest>();
                sut.Functions.Add(new FunctionsRequest
                {
                    MustThrowNameRegexException = true,
                    Name = "$invelid Name!"
                });

                Assert.IsTrue(false, "An LibreOpenAiNameRegexException was expected.");
            }
            catch (LibreOpenAiNameRegexException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiNameRegexException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }
    }
}
