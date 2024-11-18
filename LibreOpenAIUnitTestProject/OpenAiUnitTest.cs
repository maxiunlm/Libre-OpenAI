using LibreOpenAI.Exceptions;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAIUnitTestProject.Base;
using LibreOpenAIUnitTestProject.Fakes;

namespace LibreOpenAIUnitTestProject
{
    [TestClass]
    public class OpenAiUnitTest : OpenAiUnitTestBase
    {
        /* 
#if DEBUG

        [TestMethod]
        public async Task OpenAiTest_WithFunctions_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.functionsResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.AreEqual(RequestFakes.weatherFunctionName, result.Choices.First().Message.ToolCalls.First().Function.Name);
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithImageInputResquest_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.imageInputResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        }

        [TestMethod]
        public async Task OpenAiUnitTest_WithLogprobsEqualsTrue_CallsOpenAiApi()
        {
            IRequestBody request = GetRequestFrom(RequestFakes.logprobsResquest);
            IOpenAI sut = new OpenAI();

            IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Choices.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        }

        //[TestMethod]
        //public async Task OpenAiUnitTest_WithLogprobsEqualsTrue_CallsOpenAiApi()
        //{
        //    IRequestBody request = GetRequestFrom(RequestFakes.logprobsResquest);
        //    IOpenAI sut = new OpenAI();

        //    IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(1, result.Choices.Count);
        //    Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        //}

        //[TestMethod]
        //public async Task OpenAiUnitTest_With2Messages_CallsOpenAiApi()
        //{
        //    IRequestBody request = GetRequestWithLogprobsAndOffset(ResponseFakes.testFunctionCallFinishReasonSystem, ResponseFakes.testFunctionCallFinishReasonUser);
        //    IOpenAI sut = new OpenAI();

        //    IChatCompletionResponse result = await sut.Chat.Completions.Create(request);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(1, result.Choices.Count);
        //    Assert.IsFalse(string.IsNullOrWhiteSpace(result.Choices.First().Message.Content));
        //}

#endif
        // */
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

        [TestMethod]
        public void OpenAiExceptionsTextContentPart_WithListOfTextsX0_SetContentPropertyToNull()
        {
            List<TextContentPart> content = new List<TextContentPart>();
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
            List<RefusalContentPart> content = new List<RefusalContentPart>();
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
            List<ImageContentPart> content = new List<ImageContentPart>();
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
            List<AudioContentPart> content = new List<AudioContentPart>();
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
            List<TextContentPart> content = new List<TextContentPart>
            {
                new TextContentPart
                {
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
            List<RefusalContentPart> content = new List<RefusalContentPart>
            {
                new RefusalContentPart
                {
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
            List<ImageContentPart> content = new List<ImageContentPart>
            {
                new ImageContentPart
                {
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
            List<AudioContentPart> content = new List<AudioContentPart>
            {
                new AudioContentPart
                {
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
            List<TextContentPart> content = new List<TextContentPart>
            {
                new TextContentPart
                {
                    Text = "Text 1"
                },
                new TextContentPart
                {
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
            List<RefusalContentPart> content = new List<RefusalContentPart>
            {
                new RefusalContentPart
                {
                    Refusal = "Refusal 1"
                },
                new RefusalContentPart
                {
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
            List<ImageContentPart> content = new List<ImageContentPart>
            {
                new ImageContentPart
                {
                    ImageUrl = new ImageUrlContent
                    {
                        Url = "URL",
                        Detail = "Detail 1"
                    }
                },
                new ImageContentPart
                {
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
            List<AudioContentPart> content = new List<AudioContentPart>
            {
                new AudioContentPart
                {
                    InputAudio = new InputAudioContent
                    {
                        Data = "Data 1",
                        Format = "Format 1"
                    }
                },
                new AudioContentPart
                {
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
    }
}