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
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiExceptionsUnitTest : OpenAiUnitTestBase
    {
        #region HttpRequestException

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

        #endregion

        #region Json

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
        public void OpenAiExceptionsUnitTest_WithJsonSchemaTypeAndNoJsonSchema_LibreOpenAiRequiredJsonSchemaException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.ResponseFormat = new ResponseFormatRequest
                {
                    MustThrowRequiredJsonSchemaException = true,
                    Type = ResponseFormatRequest.jsonSchemaType,
                    JsonSchema = null,
                };

                Assert.IsTrue(false, "An LibreOpenAiRequiredJsonSchemaException was expected.");
            }
            catch (LibreOpenAiRequiredJsonSchemaException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiRequiredJsonSchemaException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region Exceptions

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
        public void OpenAiExceptionsUnitTest_WithNoContent_ThrowsLibreOpenAiRequiredContentException()
        {

            try
            {
                IRequestBodyExtension sut = new RequestBodyExtension
                {
                    Model = defaultModel,
                    MaxTokens = defaultMaxCompletionTokens, // NOTE: This field is deprecated, see: MaxCompletionTokens
                    FunctionCallString = RequestBodyExtension.autoFunctionCall, // NOTE: This field is deprecated, see: ToolChoice
                    Messages = new List<MessageRequest> {
                        new MessageRequest {
                            Role = MessageRequest.userRole,
                            MustThrowRequiredContentException = true,
                            Content = null
                        }
                    }
                };

                Assert.IsTrue(false, "An LibreOpenAiRequiredContentException was expected.");
            }
            catch (LibreOpenAiRequiredContentException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiRequiredContentException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsUnitTest_WithoutRequiredToolCallId_ThrowsLibreOpenAiRequiredToolCallIdException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.Messages = new List<MessageRequest>();
                sut.Messages.Add(new MessageRequest
                {
                    Role = MessageRequest.toolRole,
                    MustThrowRequiredToolCallIdException = true,
                    ToolCallId = null
                });

                Assert.IsTrue(false, "An LibreOpenAiRequiredToolCallIdException was expected.");
            }
            catch (LibreOpenAiRequiredToolCallIdException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiRequiredToolCallIdException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region ArgumentException

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
        public void OpenAiExceptionsMessageContentType_WithInvalidTypeAndMustThrowArgumentException_ThrowsArgumentException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    MustThrowArgumentException = true,
                                    Type = "WRONG TYPE",
                                    Refusal = "Refusal"
                                }
                            }
                        }
                    }
                };

                Assert.IsTrue(false, "An ArgumentException was expected.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An ArgumentException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region NameRegexException

        [TestMethod]
        public void OpenAiExceptionsUnitTest_InvaliedFunctionToolName_ThrowsLibreOpenAiNameRegexException()
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
        public void OpenAiExceptionsUnitTest_DeprecatedInvaliedFunctionName_ThrowsLibreOpenAiNameRegexException()
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

        #endregion

        #region TemperatureXorTopPException

        [TestMethod]
        public void OpenAiExceptionsUnitTest_WithNoTemperatureOrTop_ThrowsLibreOpenAiTemperatureXorTopPException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.MustThrowTemperatureOrTopPException = true;
                sut.TopP = RequestBody.defaultTopP;
                sut.Temperature = RequestBody.defaultTemperature;

                Assert.IsTrue(false, "An LibreOpenAiTemperatureXorTopPException was expected.");
            }
            catch (LibreOpenAiTemperatureXorTopPException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiTemperatureXorTopPException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsUnitTest_WithNoTopOrTemperature_ThrowsLibreOpenAiTemperatureXorTopPException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.MustThrowTemperatureOrTopPException = true;
                sut.Temperature = RequestBody.defaultTemperature;
                sut.TopP = RequestBody.defaultTopP;

                Assert.IsTrue(false, "An LibreOpenAiTemperatureXorTopPException was expected.");
            }
            catch (LibreOpenAiTemperatureXorTopPException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiTemperatureXorTopPException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region Stream

        [TestMethod]
        public void OpenAiExceptionsUnitTest_WithStreamOptionsAndStreamOnTrue_ThrowsLibreOpenAiStreamOptionsException()
        {
            IRequestBodyExtension sut = GetExtensionRequest(ResponseFakes.whatIsTheCapitalOfFrance);

            try
            {
                sut.MustThrowStreamOptionsException = true;
                sut.Stream = false;
                sut.StreamOptions = new StreamOptionsRequest();

                Assert.IsTrue(false, "An LibreOpenAiStreamOptionsException was expected.");
            }
            catch (LibreOpenAiStreamOptionsException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiStreamOptionsException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region Exeption Content Parts

        [TestMethod]
        public void OpenAiExceptionsImageContentPart_WithInvalidRoleAndMustThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = true,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.imageUrlContentType,
                                    ImageUrl = new ImageUrlContent
                                    {
                                        Detail = "Detail",
                                        Url = "URL"
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was expected.");
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsImageContentPart_WithInvalidRoleAndMustNotThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = false,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.imageUrlContentType,
                                    ImageUrl = new ImageUrlContent
                                    {
                                        Detail = "Detail",
                                        Url = "URL"
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.AreEqual(null, sut.Messages.First().Content);
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was not expected.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was not expected, but there was the '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsAudioContentPart_WithInvalidRoleAndMustThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = true,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.inputAudioContentType,
                                    InputAudio = new InputAudioContent
                                    {
                                        Data = "Data",
                                        Format = "Format"
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was expected.");
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsAudioContentPart_WithInvalidRoleAndMustNotThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = false,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.inputAudioContentType,
                                    InputAudio = new InputAudioContent
                                    {
                                        Data = "Data",
                                        Format = "Format"
                                    }
                                }
                            }
                        }
                    }
                };

                Assert.AreEqual(null, sut.Messages.First().Content);
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was not expected.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was not expected, but there was the '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithInvalidRoleAndMustThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = true,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.textContentType,
                                    Text = "Text"
                                }
                            }
                        }
                    }
                };

                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was expected.");
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithInvalidRoleAndMustNotThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = false,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.textContentType,
                                    Text = "Textr"
                                }
                            }
                        }
                    }
                };

                Assert.AreEqual(null, sut.Messages.First().Content);
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was not expected.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was not expected, but there was the '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsRefusalContentPart_WithInvalidRoleAndMustThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = true,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.refusalContentType,
                                    Refusal = "Refusal"
                                }
                            }
                        }
                    }
                };

                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was expected.");
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        [TestMethod]
        public void OpenAiExceptionsRefusalContentPart_WithInvalidRoleAndMustNotThrowWrongContentForRoleExceptionAndMustVerifyWrongContentForRoleException_ThrowsLibreOpenAiWrongContentForException()
        {
            try
            {
                IRequestBody sut = new RequestBody
                {
                    Model = defaultModel,
                    MaxCompletionTokens = defaultMaxCompletionTokens,
                    Messages = new List<MessageRequest>
                    {
                        new MessageRequest
                        {
                            Role = MessageRequest.toolRole,
                            MustVerifyWrongContentForRoleException = true,
                            MustThrowWrongContentForRoleException = false,
                            Content = new List<MessageContentType>
                            {
                                new MessageContentType
                                {
                                    Type = MessageContentType.refusalContentType,
                                    Refusal = "Refusal"
                                }
                            }
                        }
                    }
                };

                Assert.AreEqual(null, sut.Messages.First().Content);
            }
            catch (LibreOpenAiWrongContentForException)
            {
                Assert.IsTrue(false, "An LibreOpenAiWrongContentForException was not expected.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiWrongContentForException was not expected, but there was the '{ex.GetType().ToString()}'.");
            }
        }

        #endregion
    }
}
