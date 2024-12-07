namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class ChunkFakes
    {
        public const string chuckRequest = @"{
    ""model"": ""gpt-4"",
    ""messages"": [
        {""role"": ""system"", ""content"": ""You are a helpful assistant.""},
        {""role"": ""user"", ""content"": ""Tell me a joke.""}
    ],
    ""stream"": true
}";
        public const string chuckResponse = @"data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085298,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""role"":""assistant""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":0,""total_tokens"":12}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085300,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":""Why""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":1,""total_tokens"":13}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085301,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" don't""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":2,""total_tokens"":14}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085302,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" scientists""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":3,""total_tokens"":15}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085303,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" trust""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":4,""total_tokens"":16}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085304,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" atoms?""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":5,""total_tokens"":17}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085305,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" Because""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":6,""total_tokens"":18}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085306,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" they""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":7,""total_tokens"":19}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085307,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" make""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":8,""total_tokens"":20}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085308,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" up""},""finish_reason"":null}],""usage"":{""prompt_tokens"":12,""completion_tokens"":9,""total_tokens"":21}}

data: {""id"":""chatcmpl-XYZ123"",""object"":""chat.completion.chunk"",""created"":1733085309,""model"":""gpt-4"",""choices"":[{""index"":0,""delta"":{""content"":"" everything!""},""finish_reason"":""stop""}],""usage"":{""prompt_tokens"":12,""completion_tokens"":10,""total_tokens"":22}}

data: [DONE]
";
    }
}
