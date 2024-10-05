using AutoMapper;
using LibreOpenAI.DAL;
using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi;
using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content.TopLogprobs;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Refusal;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls.Function;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage.CompletionTokensDetails;
using LibreOpenAI.OpenAi.ConfigurationAi;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.Mapper
{
    internal class MappedManager
    {
        private static MappedManager? instance;
        private readonly MapperConfiguration configuration;

        public static MappedManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MappedManager();
                }

                return instance;
            }
            internal set
            {
                instance = value;
            }
        }

        private MappedManager() {
            configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<IOpenAiData, OpenAiData>().IncludeAllDerived();
                config.CreateMap<IHttpClientAi, HttpClientAi>().IncludeAllDerived();
                config.CreateMap<IConfiguration, Configuration>().IncludeAllDerived();
                config.CreateMap<IOpenAiSettings, OpenAiSettings>().IncludeAllDerived();
                config.CreateMap<IOpenAI, OpenAI>().IncludeAllDerived();
                config.CreateMap<IChat,Chat>().IncludeAllDerived();
                config.CreateMap<ICompletions, Completions>().IncludeAllDerived();
                config.CreateMap<IUsageResponse, UsageResponse>().IncludeAllDerived();
                config.CreateMap<IChoiceResponse, ChoiceResponse>().IncludeAllDerived();
                config.CreateMap<IToolCallsResponse, ToolCallsResponse>().IncludeAllDerived();
                config.CreateMap<IMessageChoiseResponse, MessageChoiseResponse>().IncludeAllDerived();
                config.CreateMap<IChatCompletionResponse, ChatCompletionResponse>().IncludeAllDerived();
                config.CreateMap<ILogprobsChoiseResponse, LogprobsChoiseResponse>().IncludeAllDerived();
                config.CreateMap<IToolCallsFunctionResponse, ToolCallsFunctionResponse>().IncludeAllDerived();
                config.CreateMap<ITopLogprobsChoiseResponse, TopLogprobsChoiseResponse>().IncludeAllDerived();
                config.CreateMap<IRefusalLogprobsChoiseResponse, RefusalLogprobsChoiseResponse>().IncludeAllDerived();
                config.CreateMap<IContentLogprobsChoiseResponse, ContentLogprobsChoiseResponse>().IncludeAllDerived();
                config.CreateMap<ICompletionTokensDetailsResponse, CompletionTokensDetailsResponse>().IncludeAllDerived();
                config.CreateMap<IRequestBody, RequestBody>().IncludeAllDerived();
                config.CreateMap<IToolRequest, ToolRequest>().IncludeAllDerived();
                config.CreateMap<IMessageRequest, MessageRequest>().IncludeAllDerived();
                config.CreateMap<IToolCallRequest, ToolCallRequest>().IncludeAllDerived();
                config.CreateMap<IFunctionRequest, FunctionRequest>().IncludeAllDerived();
                config.CreateMap<IToolChoiseRequest, ToolChoiseRequest>().IncludeAllDerived();
                config.CreateMap<IJsonSchemaRequest, JsonSchemaRequest>().IncludeAllDerived();
                config.CreateMap<IFunctionToolRequest, FunctionToolRequest>().IncludeAllDerived();
                config.CreateMap<IStreamOptionsRequest, StreamOptionsRequest>().IncludeAllDerived();
                config.CreateMap<IResponseFormatRequest, ResponseFormatRequest>().IncludeAllDerived();
                config.CreateMap<IFunctionToolChoiseRequest, FunctionToolChoiseRequest>().IncludeAllDerived();
            });
        }
    }
}
