using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.DAL.Http;
using LibreOpenAI.DAL;
using LibreOpenAI.OpenAi;
using Moq;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using Newtonsoft.Json;
using LibreOpenAIUnitTestProject.Fakes;

namespace LibreOpenAIUnitTestProject.Base
{
    public class OpenAiUnitTestBase
    {
        protected const string defaultRole = "user";
        protected const string systemRole = "system";
        protected const string defaultModel = "gpt-3.5-turbo";
        protected const int noMaxCompletionTokens = 0;
        public const int defaultMaxCompletionTokens = 50;
        protected const int aLotOfMaxCompletionTokens = 800;

        protected IOpenAI GetSut(string responseJson)
        {
            Mock<IHttpClientAi> httpClientAiMock = new Mock<IHttpClientAi>();
            HttpResponseMessage response = new HttpResponseMessage { Content = new StringContent(responseJson) };
            httpClientAiMock.Setup(o => o.PostAsync(It.IsAny<Uri>(), It.IsAny<StringContent>())).Returns(Task.FromResult(response));
            IOpenAiData openAiData = new OpenAiData { Client = httpClientAiMock.Object };
            IOpenAI sut = new OpenAI();
            sut.Chat.Completions.OpenAiData = openAiData;

            return sut;
        }

        protected IOpenAI GetSutWichThrowsException(string responseJson, Exception ex)
        {
            Mock<IHttpClientAi> httpClientAiMock = new Mock<IHttpClientAi>();
            HttpResponseMessage response = new HttpResponseMessage { Content = new StringContent(responseJson) };
            httpClientAiMock.Setup(o => o.PostAsync(It.IsAny<Uri>(), It.IsAny<StringContent>())).Throws(ex);
            IOpenAiData openAiData = new OpenAiData { Client = httpClientAiMock.Object };
            IOpenAI sut = new OpenAI();
            sut.Chat.Completions.OpenAiData = openAiData;

            return sut;
        }

        protected IRequestBodyExtension GetExtensionRequest(string contentMessage)
        {
            return new RequestBodyExtension
            {
                Model = defaultModel,
                MaxTokens = defaultMaxCompletionTokens, // NOTE: This field is deprecated, see: MaxCompletionTokens
                FunctionCallString = RequestBodyExtension.autoFunctionCall, // NOTE: This field is deprecated, see: ToolChoice
                Messages = new List<MessageRequest> {
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { contentMessage }
                    }
                }
            };
        }

        protected IRequestBody GetFunctionRequest()
        {
            RequestBody request = JsonConvert.DeserializeObject<RequestBody>(RequestFakes.functionsResquest);
            return request;
        }
        protected IRequestBody GetRequest(string contentMessage)
        {
            return new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest> {
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { contentMessage }
                    }
                }
            };
        }

        protected IRequestBody GetRequestWithNoTokens(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.MaxCompletionTokens = noMaxCompletionTokens;

            return result;
        }

        protected IRequestBody GetRequestWithTemperature(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.Temperature = 0.7m;

            return result;
        }

        protected IRequestBody GetRequestWithLogprobs(string contentMessage)
        {
            IRequestBody result = GetRequest(contentMessage);
            result.Logprobs = true;

            return result;
        }

        protected IRequestBody GetRequestWithLogprobsAndOffset(string systemContentMessage, string userContentMessage)
        {
            IRequestBody result = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Temperature = 0.5m,
                TopP = 1,
                Stop = null,
                Messages = new List<MessageRequest> {
                    new MessageRequest {
                        Role = systemRole,
                        Content = new List<string> { systemContentMessage }
                    },
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { userContentMessage }
                    }
                }
            };

            return result;
        }

        protected IRequestBody GetRequestForTokenUsage(string systemContentMessage, string userContentMessage)
        {
            IRequestBody result = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = aLotOfMaxCompletionTokens,
                Logprobs = true,
                N = 1,
                Messages = new List<MessageRequest> {
                    new MessageRequest {
                        Role = systemRole,
                        Content = new List<string> { systemContentMessage }
                    },
                    new MessageRequest {
                        Role = defaultRole,
                        Content = new List<string> { userContentMessage }
                    }
                }
            };

            return result;
        }

        protected IRequestBody GetRequestWithTemperatureAndLogprobs(string contentMessage)
        {
            IRequestBody result = GetRequestWithTemperature(contentMessage);
            result.Logprobs = true;

            return result;
        }

        protected IRequestBody GetRequestWithALotOfTokens(string contentMessage)
        {
            IRequestBody result = GetRequestWithTemperature(contentMessage);
            result.MaxCompletionTokens = aLotOfMaxCompletionTokens;

            return result;
        }
    }
}
