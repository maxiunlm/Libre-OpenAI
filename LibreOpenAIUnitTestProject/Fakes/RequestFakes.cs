namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class RequestFakes
    {
        //gpt-4o
        //gpt-3.5-turbo
        public const string weatherFunctionName = "get_current_weather";
        public const string functionsResquest = @"{
    ""model"": ""gpt-3.5-turbo"",
    ""messages"": [{
            ""role"": ""user"",
            ""content"": ""What's the weather like in Boston today?""
        }
    ],
    ""tools"": [{
            ""type"": ""function"",
            ""function"": {
                ""name"": """ + weatherFunctionName + @""",
                ""description"": ""Get the current weather in a given location"",
                ""parameters"": {
                    ""type"": ""object"",
                    ""properties"": {
                        ""location"": {
                            ""type"": ""string"",
                            ""description"": ""The city and state, e.g. San Francisco, CA"",
                        },
                        ""unit"": {
                            ""type"": ""string"",
                            ""enum"": [""celsius"", ""fahrenheit""]
                        },
                    },
                    ""required"": [""location""],
                },
            }
        }
    ],
    ""tool_choice"": ""auto""
}";
        public const string youAreAHelpfulAssistant = "You are a helpful assistant."; // TODO: Unit tests
        public const string streamingResquest = @"{
    ""model"": ""gpt-3.5-turbo"",
    ""messages"": [
      {""role"": ""system"", ""content"": """ + youAreAHelpfulAssistant + @"""},
      {""role"": ""user"", ""content"": ""Hello!""}
    ],
    ""stream"": true,
}";
        public const string hello = "Hello!"; // TODO: Unit tests
        public const string logprobsResquest = @"{
    ""messages"": [{
            ""role"": ""user"",
            ""content"": """ + hello + @"""
        }
    ],
    ""model"": ""gpt-3.5-turbo"",
    ""logprobs"": true,
    ""top_logprobs"": 2,
}";
        public const string whatIsInThisImage = "What's in this image?";
        public const string imageInputResquest = @"{
    ""model"": ""gpt-3.5-turbo"",
    ""messages"": [{
            ""role"": ""user"",
            ""content"": [{
                    ""type"": ""text"",
                    ""text"": """ + whatIsInThisImage + @""",
                }, {
                    ""type"": ""image_url"",
                    ""image_url"": {
                        ""url"": ""https://www.debian.org/Pics/openlogo-50.png"",
                    },
                }
            ],
        },
    ],
}";
    }
}
