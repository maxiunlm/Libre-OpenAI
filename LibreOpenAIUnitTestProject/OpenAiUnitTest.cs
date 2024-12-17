using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;
using Newtonsoft.Json;
using LibreOpenAI.DAL;
using Newtonsoft.Json.Linq;
using LibreOpenAI.Exceptions.OpenAI;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiUnitTest : OpenAiUnitTestBase
    {
        #region Exceptions

        [TestMethod]
        public async Task OpenAiExceptionsUnitTest_WithFakeApiKey_ThrowsLibreOpenAiAuthenticationException()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = new OpenAI("LALALALALALA");

            try
            {
                IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

                Assert.IsTrue(false, "A LibreOpenAiAuthenticationException was expected.");
            }
            catch (LibreOpenAiAuthenticationException ex)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, $"An LibreOpenAiAuthenticationException was expected, but it was '{ex.GetType().ToString()}'.");
            }
        }

        #endregion

        #region Exeption Content Parts

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithListOfTextsX0_SetContentPropertyToNull()
        {
            List<MessageContentType> content = new List<MessageContentType>();
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreEqual(null, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsRefusalContentPart_WithListOfRefusalsX0_SetContentPropertyToNull()
        {
            List<MessageContentType> content = new List<MessageContentType>();
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreEqual(null, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsImageContentPart_WithListOfImageContentPartsX0_SetContentPropertyToNull()
        {
            List<MessageContentType> content = new List<MessageContentType>();
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreEqual(null, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsAudioContentPart_WithListOfAudioContentPartsX0_SetContentPropertyToNull()
        {
            List<MessageContentType> content = new List<MessageContentType>();
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreEqual(null, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithListOfTextsX1_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.textContentType,
                    Text = "Text"
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content.First(), sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsRefusalContentPart_WithListOfRefusalsX1_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.refusalContentType,
                    Refusal = "Refusal"
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content.First(), sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsImageContentPart_WithListOfImageContentPartsX1_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.imageUrlContentType,
                    ImageUrl = new ImageUrlContent
                    {
                        Url = "URL",
                        Detail = "Detail"
                    }
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content.First(), sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsAudioContentPart_WithListOfAudioContentPartsX1_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
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
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content.First(), sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithListOfTextsX2_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.textContentType,
                    Text = "Text 1"
                },
                new MessageContentType
                {
                    Type = MessageContentType.textContentType,
                    Text = "Text 2"
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsRefusalContentPart_WithListOfRefusalsX2_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.refusalContentType,
                    Refusal = "Refusal 1"
                },
                new MessageContentType
                {
                    Type = MessageContentType.refusalContentType,
                    Refusal = "Refusal 2"
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.assistantRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsImageContentPart_WithListOfImageContentPartsX2_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.imageUrlContentType,
                    ImageUrl = new ImageUrlContent
                    {
                        Url = "URL",
                        Detail = "Detail 1"
                    }
                },
                new MessageContentType
                {
                    Type = MessageContentType.imageUrlContentType,
                    ImageUrl = new ImageUrlContent
                    {
                        Url = "URL",
                        Detail = "Detail 2"
                    }
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content, sut.Messages.First().Content);
        }

        [TestMethod]
        public void OpenAiExceptionsAudioContentPart_WithListOfAudioContentPartsX2_SetContentProperty()
        {
            List<MessageContentType> content = new List<MessageContentType>
            {
                new MessageContentType
                {
                    Type = MessageContentType.inputAudioContentType,
                    InputAudio = new InputAudioContent
                    {
                        Data = "Data 1",
                        Format = "Format 1"
                    }
                },
                new MessageContentType
                {
                    Type = MessageContentType.inputAudioContentType,
                    InputAudio = new InputAudioContent
                    {
                        Data = "Data 2",
                        Format = "Format 2"
                    }
                }
            };
            IRequestBody sut = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest>
                {
                    new MessageRequest
                    {
                        MustVerifyWrongContentForRoleException = true,
                        Role = MessageRequest.userRole,
                        Content =content
                    }
                }
            };

            Assert.AreSame(content, sut.Messages.First().Content);
        }

        #endregion

        #region Create

        [TestMethod]
        public async Task Create_WhatIsTheCapitalofFrance()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_YouAreAHelpfulAssistante()
        {
            IRequestBody request = GetRequest(ResponseFakes.youAreAHelpfulAssistant);
            IOpenAI sut = GetSut(ResponseFakes.youAreAHelpfulAssistantJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.helloThereHowMayIAssistYouToday, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_MultiChoiceRequestJson()
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
        public async Task Create_TruncatedResponseJson()
        {
            IRequestBody request = GetRequestWithTemperature(ResponseFakes.testTruncatedResponse);
            IOpenAI sut = GetSut(ResponseFakes.truncatedResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.thisResponseWasCutShort, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_LogprobsResponseJson()
        {
            IRequestBody request = GetRequestWithTemperatureAndLogprobs(ResponseFakes.testForLogprobsPresent);
            IOpenAI sut = GetSut(ResponseFakes.logprobsResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.hereIAResponseWithLogprobs, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_HighTokenUsageResponseJson()
        {
            IRequestBody request = GetRequestWithALotOfTokens(ResponseFakes.testHighTokenUsageResponse);
            IOpenAI sut = GetSut(ResponseFakes.highTokenUsageResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.hereIsALongResponseToTestHighTokenUsage, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_EmptyChoicesResponseJson()
        {
            IRequestBody request = GetRequestWithNoTokens(ResponseFakes.testEmptyChoicesResponse);
            IOpenAI sut = GetSut(ResponseFakes.emptyChoicesResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(noMaxCompletionTokens, result.Choices.Count);
        }

        [TestMethod]
        public async Task Create_AStandardCompletionResponseFromChatGptJson()
        {
            IRequestBody request = GetRequest(ResponseFakes.testAStandardCompletionResponseFromChatGpt);
            IOpenAI sut = GetSut(ResponseFakes.aStandardCompletionResponseFromChatGptJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.aStandardCompletionResponseFromChat, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_LogprobsResponseWithTextOffsetJson()
        {
            IRequestBody request = GetRequestWithLogprobs(ResponseFakes.testLogprobsResponseWithTextOffset);
            IOpenAI sut = GetSut(ResponseFakes.logprobsResponseWithTextOffsetJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.logprobsResponseWithTextOffset, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_FunctionCallFinishReasonJson()
        {
            IRequestBody request = GetRequestWithLogprobsAndOffset(ResponseFakes.testFunctionCallFinishReasonSystem, ResponseFakes.testFunctionCallFinishReasonUser);
            IOpenAI sut = GetSut(ResponseFakes.functionCallFinishReasonJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.functionCallFinishReason, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_DetailedTokenUsageResponseJson()
        {
            IRequestBody request = GetRequestForTokenUsage(ResponseFakes.testDtailedTokenUsageResponseSystem, ResponseFakes.testDetailedTokenUsageResponseUser);
            IOpenAI sut = GetSut(ResponseFakes.detailedTokenUsageResponseJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.detailedTokenUsageResponse, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task Create_WithJsonRequest_ReturnsIChatCompletionResponse()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, result.Choices.First().Message.Content);
        }

        [TestMethod]
        public async Task CreateJToken_WithIRequestBody_ReturnsJToken()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            JToken result = await sut.Chat.Completions.CreateJToken(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result["choices"].Count());
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, ((JValue)result["choices"][0]["message"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateJToken_WithJsonRequest_ReturnsJToken()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            JToken result = await sut.Chat.Completions.CreateJToken(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result["choices"].Count());
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, ((JValue)result["choices"][0]["message"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateJToken_WithJTokenRequest_ReturnsJToken()
        {
            dynamic request = GetJTokenRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            JToken result = await sut.Chat.Completions.CreateJToken(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result["choices"].Count());
            Assert.AreEqual(ResponseFakes.theCapitalOfFranceIsParis, ((JValue)result["choices"][0]["message"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateJson_WithIRequestBody_ReturnsJson()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            string result = await sut.Chat.Completions.CreateJson(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf(ResponseFakes.theCapitalOfFranceIsParis) > 0);
        }

        [TestMethod]
        public async Task CreateJson_WithJsonRequest_ReturnsJson()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            string result = await sut.Chat.Completions.CreateJson(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf(ResponseFakes.theCapitalOfFranceIsParis) > 0);
        }

        [TestMethod]
        public async Task CreateJson_WithJTokenRequest_ReturnsJson()
        {
            dynamic request = GetJTokenRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            string result = await sut.Chat.Completions.CreateJson(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf(ResponseFakes.theCapitalOfFranceIsParis) > 0);
        }

        #endregion

        #region CreateStream

        [TestMethod]
        public async Task CreateStream_WithStreamTrue_ReturnsChunksWithUsage()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(12, result.First().Usage.TotalTokens);
        }

        [TestMethod]
        public async Task CreateStreamJToken_WithIRequestBody_ReturnsJTokenChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            JToken result = await sut.Chat.Completions.CreateStreamJToken(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(((JArray)result).ToList().Any());
            Assert.AreEqual("Why", ((JValue)result [1]["choices"][0]["delta"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateStreamJToken_WithJsonRequest_ReturnsJTokenChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            string requestJson = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            JToken result = await sut.Chat.Completions.CreateStreamJToken(requestJson);

            Assert.IsNotNull(result);
            Assert.IsTrue(((JArray)result).ToList().Any());
            Assert.AreEqual("Why", ((JValue)result [1]["choices"][0]["delta"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateStreamJToken_WithJTokenRequest_ReturnsJTokenChunks()
        {
            dynamic request = GetJTokenStremRequest(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            JToken result = await sut.Chat.Completions.CreateStreamJToken(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(((JArray)result).ToList().Any());
            Assert.AreEqual("Why", ((JValue)result[1]["choices"][0]["delta"]["content"]).Value);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithIRequestBody_ReturnsJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("\"finish_reason\":\"stop\"") > 0);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithJsonRequest_ReturnsJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            string requestJson = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(requestJson);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("\"finish_reason\":\"stop\"") > 0);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithJTokenRequest_ReturnsJsonChunks()
        {
            dynamic request = GetJTokenStremRequest(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(request);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("\"finish_reason\":\"stop\"") > 0);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithIRequestBodyAndRaw_ReturnsRawJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(request, true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("data:") == 0);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithJsonRequestAndRaw_ReturnsRawJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            string requestJson = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(requestJson, true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("data:") == 0);
        }

        [TestMethod]
        public async Task CreateStreamJson_WithJTokenRequestAndRaw_ReturnsRawJsonChunks()
        {
            dynamic request = GetJTokenStremRequest(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(request, true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("data:") == 0);
        }

        #endregion
    }
}