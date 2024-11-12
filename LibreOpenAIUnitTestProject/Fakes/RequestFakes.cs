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
    }
}
