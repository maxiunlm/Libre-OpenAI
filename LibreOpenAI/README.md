# Libre-OpenAI (Beta)
An Open AI Nuget for .NET applications (.NET 8 or higher), It is "Libre" (free and for free).
Remember, Libre-OpenAI and its Extensions are Beta versions, they are under construction!

You can download our Nuget from:

https://www.nuget.org/packages/LibreOpenAI/

Please, see these unit tests to learn how to use this Nuget:

https://github.com/maxiunlm/Libre-OpenAI/blob/main/LibreOpenAIUnitTestProject/OpenAiUnitTest.cs

And see the Libre OpenAI Extensions Nuget to learn how to use the extensions of the Libre Open AI Nuget:

https://github.com/maxiunlm/Libre-OpenAI/blob/main/LibreOpenAIExtensions/README.md

## Support this project 💖

If you find this project useful, consider supporting us by making a donation via PayPal. Your support helps keep this project alive and maintained.

- Donate to **Libre-OpenAI (Beta)**: [![Donate](https://img.shields.io/badge/Donate-PayPal-blue.svg)](https://www.paypal.com/donate?hosted_button_id=94GX8T4KXEDLQ&item_name=LibreOpenAI&custom=CsharpSolution)

### Donate via QR Code
You can also scan the QR code below to make a donation:

![QR Code](https://raw.githubusercontent.com/maxiunlm/Libre-OpenAI/refs/heads/main/images/Libre-OpenAI-Beta-QR.png)

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
    string content = result.choices[0].message.content.Value;

    // OR, result will be a IDictionary<string, object> object based on the JSON result
    ((IDictionary<string, object>)
        ((IDictionary<string, object>)
            ((IList<object>)result["choices"])[0])["message"])["content"];
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Chat.Completions.CreateDynamic(request);

    // result will be a dynamic object based on the JSON result
    string content = result.choices[0].message.content.Value;

    // OR, result will be a IDictionary<string, object> object based on the JSON result
    ((IDictionary<string, object>)
        ((IDictionary<string, object>)
            ((IList<object>)result["choices"])[0])["message"])["content"];
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

    // result will be a IDictionary<string, object> object based on the JSON result
    string content = result.choices[0].message.content.Value;

    // OR, result will be a IDictionary<string, object> object based on the JSON result
    ((IDictionary<string, object>)
        ((IDictionary<string, object>)
            ((IList<object>)result["choices"])[0])["message"])["content"];
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
    string content = result[1].choices[0].delta.content.Value;
```
###### Using JSON
```cs
    string request = "{\"max_completion_tokens\":50,\"model\":\"gpt-4o\",\"messages\":[{\"role\":\"user\",\"content\":\"What is the capital of France?\"}],\"n\":1}";
    IOpenAI openAi = new OpenAI();
    
    dynamic result = await sut.Chat.Completions.CreateStreamDynamic(request);
    // result will be a dynamic array of objects based on the JSON result
    string content = result[1].choices[0].delta.content.Value;
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
    string content = result[1].choices[0].delta.content.Value;
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



### Batches
#### Create
##### Returning dynamic
###### Using JSON
```cs
    string request = @"{
        ""input_file_id"": ""file-abc123"",
        ""endpoint"": ""/v1/chat/completions"",
        ""completion_window"": ""24h""
    }";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Batches.CreateDynamic(request);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```
###### Using dynamic type
```cs
    dynamic request = new {
        input_file_id = "file-abc123",
        endpoint = "/v1/chat/completions",
        completion_window = "24h"
    };
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Batches.CreateDynamic(request);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```

##### Returning JSON
###### Using JSON
```cs
    string request = @"{
        ""input_file_id"": ""file-abc123"",
        ""endpoint"": ""/v1/chat/completions"",
        ""completion_window"": ""24h""
    }";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Batches.CreateJson(request);
    // result will be a JSON
```
###### Using dynamic type
```cs
    dynamic request = new {
        input_file_id = "file-abc123",
        endpoint = "/v1/chat/completions",
        completion_window = "24h"
    };
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Batches.CreateJson(request);
    // result will be a JSON
```

#### Retrieve
##### Returning dynamic
```cs
    string batchId = "batch_abc123";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Batches.RetrieveDynamic(batchId);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```

##### Returning JSON
```cs
    string batchId = "batch_abc123";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Batches.RetrieveJson(batchId);
    // result will be a JSON
```

#### Cancel
##### Returning dynamic
```cs
    string batchId = "batch_abc123";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Batches.CancelDynamic(batchId);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```

##### Returning JSON
```cs
    string batchId = "batch_abc123";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Batches.CancelJson(batchId);
    // result will be a JSON
```

#### List
##### Returning dynamic
```cs
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Batches.ListDynamic();
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```

##### Returning JSON
```cs
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Batches.ListJson();
    // result will be a JSON
```



### Create Embeddings
#### Returning dynamic
##### Using JSON
```cs
    string request = @"{
        model: ""text-embedding-ada-002"",
        input: ""The quick brown fox jumped over the lazy dog"",
        encoding_format: ""float"",
    }";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Embeddings.CreateDynamic(request);
    // result will be a dynamic array of numbers based on the JSON result
    double first = result.data[0].embedding[0].Value;
```
##### Using dynamic type
```cs
    dynamic request = new {
        model = "text-embedding-ada-002",
        input = "The quick brown fox jumped over the lazy dog",
        encoding_format = "float",
    };
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.Embeddings.CreateDynamic(request);
    // result will be a dynamic array of numbers based on the JSON result
    double first = result.data[0].embedding[0].Value;
```

#### Returning JSON
##### Using JSON
```cs
    string request = @"{
        model: ""text-embedding-ada-002"",
        input: ""The quick brown fox jumped over the lazy dog"",
        encoding_format: ""float"",
    }";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Embeddings.CreateJson(request);
    // result will be a JSON
```
##### Using dynamic type
```cs
    dynamic request = new {
        model = "text-embedding-ada-002",
        input = "The quick brown fox jumped over the lazy dog",
        encoding_format = "float",
    };
    IOpenAI openAi = new OpenAI();

    string result = await openAi.Embeddings.CreateJson(request);
    // result will be a JSON
```



### Fine-tuning - Jobs
#### Create
##### Returning dynamic
###### Using JSON
```cs
    string request = @"{
      ""object"": ""fine_tuning.job"",
      ""id"": ""ftjob-abc123"",
      ""model"": ""gpt-4o-mini-2024-07-18"",
      ""created_at"": 1721764800,
      ""fine_tuned_model"": null,
      ""organization_id"": ""org-123"",
      ""result_files"": [],
      ""status"": ""queued"",
      ""validation_file"": null,
      ""training_file"": ""file-abc123"",
      ""method"": {
        ""type"": ""supervised"",
        ""supervised"": {
          ""hyperparameters"": {
            ""batch_size"": ""auto"",
            ""learning_rate_multiplier"": ""auto"",
            ""n_epochs"": ""auto"",
          }
        }
      }
    }";
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.FineTuning.Jobs.CreateDynamic(request);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;;
```
###### Using dynamic type
```cs
    dynamic request = new {
      object = "fine_tuning.job",
      id = "ftjob-abc123",
      model = "gpt-4o-mini-2024-07-18",
      created_at = 1721764800,
      fine_tuned_model = null,
      organization_id = "org-123",
      result_files = new [],
      status = "queued",
      validation_file = null,
      training_file = "file-abc123",
      method = new {
        type = "supervised",
        supervised = new {
          hyperparameters = new {
            batch_size = "auto",
            learning_rate_multiplier = "auto",
            n_epochs = "auto",
          }
        }
      }
    };
    IOpenAI openAi = new OpenAI();

    dynamic result = await openAi.FineTuning.Jobs.CreateDynamic(request);
    // result will be a dynamic object based on the JSON result
    string id = result.id.Value;
```

##### Returning JSON
###### Using JSON
```cs
    string request = @"{
      ""object"": ""fine_tuning.job"",
      ""id"": ""ftjob-abc123"",
      ""model"": ""gpt-4o-mini-2024-07-18"",
      ""created_at"": 1721764800,
      ""fine_tuned_model"": null,
      ""organization_id"": ""org-123"",
      ""result_files"": [],
      ""status"": ""queued"",
      ""validation_file"": null,
      ""training_file"": ""file-abc123"",
      ""method"": {
        ""type"": ""supervised"",
        ""supervised"": {
          ""hyperparameters"": {
            ""batch_size"": ""auto"",
            ""learning_rate_multiplier"": ""auto"",
            ""n_epochs"": ""auto"",
          }
        }
      }
    }";
    IOpenAI openAi = new OpenAI();

    string result = await openAi.FineTuning.Jobs.CreateJson(request);
    // result will be a JSON
```
###### Using dynamic type
```cs
    dynamic request = new {
      object = "fine_tuning.job",
      id = "ftjob-abc123",
      model = "gpt-4o-mini-2024-07-18",
      created_at = 1721764800,
      fine_tuned_model = null,
      organization_id = "org-123",
      result_files = new [],
      status = "queued",
      validation_file = null,
      training_file = "file-abc123",
      method = new {
        type = "supervised",
        supervised = new {
          hyperparameters = new {
            batch_size = "auto",
            learning_rate_multiplier = "auto",
            n_epochs = "auto",
          }
        }
      }
    };
    IOpenAI openAi = new OpenAI();

    string result = await openAi.FineTuning.Jobs.CreateJson(request);
    // result will be a JSON
```



## Support this project 💖

If you find this project useful, consider supporting us by making a donation via PayPal. Your support helps keep this project alive and maintained.

- Donate to **Libre-OpenAI (Beta)**: [![Donate](https://img.shields.io/badge/Donate-PayPal-blue.svg)](https://www.paypal.com/donate?hosted_button_id=94GX8T4KXEDLQ&item_name=LibreOpenAI&custom=CsharpSolution)

### Donate via QR Code
You can also scan the QR code below to make a donation:

![QR Code](https://raw.githubusercontent.com/maxiunlm/Libre-OpenAI/refs/heads/main/images/Libre-OpenAI-Beta-QR.png)