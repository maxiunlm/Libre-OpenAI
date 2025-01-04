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
        #region Completions
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
        public async Task CreateDynamic_WithIRequestBody_ReturnsJson()
        {
            IRequestBody request = GetRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            dynamic result = await sut.Chat.Completions.CreateDynamic(request);
            string content = result.choices[0].message.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
        }

        [TestMethod]
        public async Task CreateDynamic_WithJsonRequest_ReturnsJson()
        {
            string request = JsonConvert.SerializeObject(GetRequest(ResponseFakes.whatIsTheCapitalOfFrance), OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            dynamic result = await sut.Chat.Completions.CreateDynamic(request);
            string content = result.choices[0].message.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
        }

        [TestMethod]
        public async Task CreateDynamic_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = GetDynamicRequest(ResponseFakes.whatIsTheCapitalOfFrance);
            IOpenAI sut = GetSut(ResponseFakes.theCapitalOfFranceIsParisJson);

            dynamic result = await sut.Chat.Completions.CreateDynamic(request);
            string content = result.choices[0].message.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
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
        public async Task CreateJson_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = GetDynamicRequest(ResponseFakes.whatIsTheCapitalOfFrance);
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
        public async Task CreateStreamDynamic_WithIRequestBody_ReturnsJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);
            string content = result[1].choices[0].delta.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
        }

        [TestMethod]
        public async Task CreateStreamDynamic_WithJsonRequest_ReturnsJsonChunks()
        {
            IRequestBody request = GetRequestFrom(ChunkFakes.chuckRequest);
            string requestJson = JsonConvert.SerializeObject(request, OpenAiData.jsonSettings);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            dynamic result = await sut.Chat.Completions.CreateStreamDynamic(requestJson);
            string content = result[1].choices[0].delta.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
        }

        [TestMethod]
        public async Task CreateStreamDynamic_WithDynamicRequest_ReturnsJsonChunks()
        {
            dynamic request = GetJTokenStremRequest(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);
            string content = result[1].choices[0].delta.content.Value;

            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));
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
        public async Task CreateStreamJson_WithDynamicRequest_ReturnsJsonChunks()
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
        public async Task CreateStreamJson_WithDynamicRequestAndRaw_ReturnsRawJsonChunks()
        {
            dynamic request = GetJTokenStremRequest(ChunkFakes.chuckRequest);
            IOpenAI sut = GetSut(ChunkFakes.chuckResponse);

            string result = await sut.Chat.Completions.CreateStreamJson(request, true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IndexOf("data:") == 0);
        }

        #endregion
        #endregion

        #region Embeddings

        [TestMethod]
        public async Task CreateJson_Embeddings_WithJsonRequest_ReturnsJson()
        {
            IOpenAI sut = GetEmbeddingsSut(EmbeddingsFakes.responseCreate);

            string result = await sut.Embeddings.CreateJson(EmbeddingsFakes.resquestCreate);

            Assert.AreEqual(EmbeddingsFakes.responseCreate, result);
        }

        [TestMethod]
        public async Task CreateJson_Embeddings_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = JToken.Parse(EmbeddingsFakes.resquestCreate);
            IOpenAI sut = GetEmbeddingsSut(EmbeddingsFakes.responseCreate);

            string result = await sut.Embeddings.CreateJson(request);


            Assert.AreEqual(EmbeddingsFakes.responseCreate, result);
        }

        [TestMethod]
        public async Task CreateDynamic_Embeddings_WithJsonRequest_ReturnsDynamic()
        {
            IOpenAI sut = GetEmbeddingsSut(EmbeddingsFakes.responseCreate);

            dynamic result = await sut.Embeddings.CreateDynamic(EmbeddingsFakes.resquestCreate);
            double first = result.data[0].embedding[0].Value;

            Assert.AreEqual(0.0023064255, first);
        }

        [TestMethod]
        public async Task CreateDynamic_Embeddings_WithDynamicRequest_ReturnsDynamic()
        {
            dynamic request = JToken.Parse(EmbeddingsFakes.resquestCreate);
            IOpenAI sut = GetEmbeddingsSut(EmbeddingsFakes.responseCreate);

            dynamic result = await sut.Embeddings.CreateDynamic(request);

            Assert.IsNotNull(result.data[0].embedding[0]);
        }

        #endregion

        #region FineTuning Jobs

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_WithJsonRequest_ReturnsJson()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateDefault);

            string result = await sut.FineTuning.Jobs.CreateJson(FineTuningJobsFakes.resquestCreateDefault);

            Assert.AreEqual(FineTuningJobsFakes.responseCreateDefault, result);
        }

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateDefault);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateDefault);

            string result = await sut.FineTuning.Jobs.CreateJson(request);


            Assert.AreEqual(FineTuningJobsFakes.responseCreateDefault, result);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_WithJsonRequest_ReturnsDynamic()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateDefault);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(FineTuningJobsFakes.resquestCreateDefault);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_WithDynamicRequest_ReturnsDynamic()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateDefault);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateDefault);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(request);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_Epochs_WithJsonRequest_ReturnsJson()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateEpochs);

            string result = await sut.FineTuning.Jobs.CreateJson(FineTuningJobsFakes.resquestCreateEpochs);

            Assert.AreEqual(FineTuningJobsFakes.responseCreateEpochs, result);
        }

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_Epochs_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateEpochs);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateEpochs);

            string result = await sut.FineTuning.Jobs.CreateJson(request);


            Assert.AreEqual(FineTuningJobsFakes.responseCreateEpochs, result);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_Epochs_WithJsonRequest_ReturnsDynamic()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateEpochs);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(FineTuningJobsFakes.resquestCreateEpochs);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_Epochs_WithDynamicRequest_ReturnsDynamic()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateEpochs);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateEpochs);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(request);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_ValidationFile_WithJsonRequest_ReturnsJson()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateValidationFile);

            string result = await sut.FineTuning.Jobs.CreateJson(FineTuningJobsFakes.resquestCreateValidationFile);

            Assert.AreEqual(FineTuningJobsFakes.responseCreateValidationFile, result);
        }

        [TestMethod]
        public async Task CreateJson_FineTuningJobs_ValidationFile_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateValidationFile);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateValidationFile);

            string result = await sut.FineTuning.Jobs.CreateJson(request);


            Assert.AreEqual(FineTuningJobsFakes.responseCreateValidationFile, result);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_ValidationFile_WithJsonRequest_ReturnsDynamic()
        {
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateValidationFile);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(FineTuningJobsFakes.resquestCreateValidationFile);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        [TestMethod]
        public async Task CreateDynamic_FineTuningJobs_ValidationFile_WithDynamicRequest_ReturnsDynamic()
        {
            dynamic request = JToken.Parse(FineTuningJobsFakes.resquestCreateValidationFile);
            IOpenAI sut = GetPostFineTuningJobsSut(FineTuningJobsFakes.responseCreateValidationFile);

            dynamic result = await sut.FineTuning.Jobs.CreateDynamic(request);
            string id = result.id.Value;

            Assert.AreEqual("ftjob-abc123", id);
        }

        #endregion

        #region Batches
        #region Create

        [TestMethod]
        public async Task CreateJson_Batches_WithJsonRequest_ReturnsJson()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCreate);

            string result = await sut.Batches.CreateJson(BatchesFakes.resquestCreate);

            Assert.AreEqual(BatchesFakes.responseCreate, result);
        }

        [TestMethod]
        public async Task CreateJson_Batches_WithDynamicRequest_ReturnsJson()
        {
            dynamic request = JToken.Parse(BatchesFakes.resquestCreate);
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCreate);

            string result = await sut.Batches.CreateJson(request);


            Assert.AreEqual(BatchesFakes.responseCreate, result);
        }

        [TestMethod]
        public async Task CreateDynamic_Batches_WithJsonRequest_ReturnsDynamic()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCreate);

            dynamic result = await sut.Batches.CreateDynamic(BatchesFakes.resquestCreate);
            string id = result.id.Value;

            Assert.AreEqual("batch_abc123", id);
        }

        [TestMethod]
        public async Task CreateDynamic_Batches_WithDynamicRequest_ReturnsDynamic()
        {
            dynamic request = JToken.Parse(BatchesFakes.resquestCreate);
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCreate);

            dynamic result = await sut.Batches.CreateDynamic(request);
            string id = result.id.Value;

            Assert.AreEqual("batch_abc123", id);
        }

        #endregion

        #region Retrieve

        [TestMethod]
        public async Task RetrieveJson_Batches_WithRetrieveBatchId_ReturnsJson()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseRetrieve);

            string result = await sut.Batches.RetrieveJson(BatchesFakes.resquestBatchId);


            Assert.AreEqual(BatchesFakes.responseRetrieve, result);
        }

        [TestMethod]
        public async Task RetrieveDynamic_Batches_WithRetrieveBatchId_ReturnsDynamic()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseRetrieve);

            dynamic result = await sut.Batches.RetrieveDynamic(BatchesFakes.resquestBatchId);
            string id = result.id.Value;

            Assert.AreEqual("batch_abc123", id);
        }

        #endregion

        #region Cancel

        [TestMethod]
        public async Task CancelJson_Batches_WithRetrieveBatchId_ReturnsJson()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCancel);

            string result = await sut.Batches.CancelJson(BatchesFakes.resquestBatchId);


            Assert.AreEqual(BatchesFakes.responseCancel, result);
        }

        [TestMethod]
        public async Task CancelDynamic_Batches_WithRetrieveBatchId_ReturnsDynamic()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseCancel);

            dynamic result = await sut.Batches.CancelDynamic(BatchesFakes.resquestBatchId);
            string id = result.id.Value;

            Assert.AreEqual("batch_abc123", id);
        }

        #endregion

        #region List

        [TestMethod]
        public async Task ListJson_Batches_WithRetrieveBatchId_ReturnsJson()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseList);

            string result = await sut.Batches.ListJson();


            Assert.AreEqual(BatchesFakes.responseList, result);
        }

        [TestMethod]
        public async Task ListDynamic_Batches_WithRetrieveBatchId_ReturnsDynamic()
        {
            IOpenAI sut = GetBatchesSut(BatchesFakes.responseList);

            dynamic result = await sut.Batches.ListDynamic();
            string id = result.data[0].id.Value;

            Assert.AreEqual("batch_abc123", id);
        }

        #endregion
        #endregion
    }
}