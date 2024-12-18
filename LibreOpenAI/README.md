# Libre-OpenAI (Beta)
An Open AI Nuget for .NET applications (.NET 8 or higher), It is "Libre" (free and for free).
Libre-OpenAI is under construction, for now we are working only in Text Content generation.

The current Beta version is 0.1.3.

Please, see these unit tests to learn how to use this Nuget:

https://github.com/maxiunlm/Libre-OpenAI/blob/main/LibreOpenAIUnitTestProject/OpenAiUnitTest.cs

## How to use Libre Open AI
### Create Completions
#### Using IRequestBody
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
    string contentResult = result.Choices.First().Message.Content;
```
#### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();

    IChatCompletionResponse result = await openAi.Chat.Completions.Create(request);
    string contentResult = result.Choices.First().Message.Content;
```
#### Using dynamic type
```cs
    dynamic request = new {
        model = defaultModel,
        max_completion_tokens = defaultMaxCompletionTokens,
        messages = new[] {
            new {
                role = defaultRole,
                content = ResponseFakes.whatIsTheCapitalOfFrance
            }
        }
    };
    IOpenAI openAi = new OpenAI();

    IChatCompletionResponse result = await openAi.Chat.Completions.Create(request);
    string contentResult = result.Choices.First().Message.Content;
```

##### Returning dynamic
###### Using IRequestBody
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

    dynamic result = await openAi.Chat.Completions.CreateDynamic(request);  
    // result will be a dynamic object based on the JSON result
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Chat.Completions.CreateDynamic(request);  
    // result will be a dynamic object based on the JSON result
```
###### Using dynamic type
```cs
    dynamic request = new {
        model = defaultModel,
        max_completion_tokens = defaultMaxCompletionTokens,
        messages = new[] {
            new {
                role = defaultRole,
                content = ResponseFakes.whatIsTheCapitalOfFrance
            }
        }
    };
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Chat.Completions.CreateDynamic(request);   
    // result will be a dynamic object based on the JSON result
```

##### Returning JSON
###### Using IRequestBody
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

    string result = await openAi.Chat.Completions.CreateJson(request);  
    // result will be a JSON
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Chat.Completions.CreateJson(request);  
    // result will be a JSON
```
###### Using dynamic type
```cs
    dynamic request = new {
        model = defaultModel,
        max_completion_tokens = defaultMaxCompletionTokens,
        messages = new[] {
            new {
                role = defaultRole,
                content = ResponseFakes.whatIsTheCapitalOfFrance
            }
        }
    };
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Chat.Completions.CreateJson(request);    
    // result will be a JSON
```


### Create Stream Completions
#### Using IRequestBody
```cs
    IRequestBody request = new RequestBody
    {
        Model = "gpt-4o",
        Messages = new List<MessageRequest> {
            new MessageRequest {
                Role = "system",
                Content = "You are a helpful assistant." // NOTE: complete here your request question
            },
            new MessageRequest {
                Role = "user",
                Content = "Hello!" // NOTE: complete here your request question
            }
        },
        Stream = true
    };

    IOpenAI openAi = new OpenAI();
    
    List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);
    // For ex.: contentResult will contain all the result prats separated by "\t" (TAB character).
    string contentResult = string.Join('\t', result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).ToList());
```
#### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-4o\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();
    
    List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);
    // For ex.: contentResult will contain all the result prats separated by "\t" (TAB character).
    string contentResult = string.Join('\t', result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).ToList());
```
#### Using dynamic type
```cs
    dynamic request = new
    {
        model = "gpt-4o",
        messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = "Hello!" }
            },
        stream = true
    };
    IOpenAI openAi = new OpenAI();
    
    List<IChatCompletionChunk> result = await sut.Chat.Completions.CreateStream(request);
    // For ex.: contentResult will contain all the result prats separated by "\t" (TAB character).
    string contentResult = string.Join('\t', result.SelectMany(o => o.Choices.Select(o => o.Delta.Content)).ToList());
```

##### Returning dynamic
###### Using IRequestBody
```cs
    IRequestBody request = new RequestBody
    {
        Model = "gpt-4o",
        Messages = new List<MessageRequest> {
            new MessageRequest {
                Role = "system",
                Content = "You are a helpful assistant." // NOTE: complete here your request question
            },
            new MessageRequest {
                Role = "user",
                Content = "Hello!" // NOTE: complete here your request question
            }
        },
        Stream = true
    };

    IOpenAI openAi = new OpenAI();
    
    dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);  
    // result will be a dynamic array of objects based on the JSON result
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-4o\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();
    
    dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);
    // result will be a dynamic array of objects based on the JSON result
```
###### Using dynamic type
```cs
    dynamic request = new
    {
        model = "gpt-4o",
        messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = "Hello!" }
            },
        stream = true
    };
    IOpenAI openAi = new OpenAI();
    
    dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);
    // result will be a dynamic array of objects based on the JSON result
```

##### Returning JSON
###### Using IRequestBody
```cs
    IRequestBody request = new RequestBody
    {
        Model = "gpt-4o",
        Messages = new List<MessageRequest> {
            new MessageRequest {
                Role = "system",
                Content = "You are a helpful assistant." // NOTE: complete here your request question
            },
            new MessageRequest {
                Role = "user",
                Content = "Hello!" // NOTE: complete here your request question
            }
        },
        Stream = true
    };

    IOpenAI openAi = new OpenAI();
    
    string result = await sut.Chat.Completions.CreateStreamJson(request);
    // result will be a JSON array
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-4o\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();
    
    string result = await sut.Chat.Completions.CreateStreamJson(request);
    // result will be a JSON array
```
###### Using dynamic type
```cs
    dynamic request = new
    {
        model = "gpt-4o",
        messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = "Hello!" }
            },
        stream = true
    };
    IOpenAI openAi = new OpenAI();
    
    string result = await sut.Chat.Completions.CreateStreamJson(request);
    // result will be a JSON array
```
###### Expecting raw JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-4o\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();
    
    string result = await sut.Chat.Completions.CreateStreamJson(request, true);

    // result will contain a list of "data: {...}" JSON objects that can't be parsed directly as JSON !
```
