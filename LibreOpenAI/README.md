# Libre-OpenAI (Beta)
An Open AI Nuget for .NET applications (.NET 8 or higher), It is "Libre" (free and for free).
Libre-OpenAI is under construction, for now we are working only in Text Content generation.

The current Beta version is 0.1.2.

Please, see these unit tests to learn how to use this Nuget:

https://github.com/maxiunlm/Libre-OpenAI/blob/main/LibreOpenAIUnitTestProject/OpenAiUnitTest.cs

## Sample
```cs
    IRequestBody request = new RequestBody
            {
                Model = defaultModel,
                MaxCompletionTokens = defaultMaxCompletionTokens,
                Messages = new List<MessageRequest> {
                    new MessageRequest {
                        Role = defaultRole,
                        Content = "What is the capital of France?" // NOTE: complete here your request question
                    }
                }
            };
    IOpenAI openAi = new OpenAI();

    IChatCompletionResponse result = await openAi.Chat.Completions.Create(request);
```