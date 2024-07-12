[![](https://img.shields.io/nuget/v/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.client.chat/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.client.chat/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenAI.Client.Chat
### An async thread-safe singleton for the OpenAI Chat (completions) client

This library provides an implementation for interacting with the OpenAI service. It allows you to configure and utilize a ChatClient to perform various tasks using OpenAI's models.

For the Azure version of this: [Soenneker.Azure.OpenAI.Client.Chat](https://github.com/soenneker/soenneker.azure.openai.client.chat)

## Installation

```
dotnet add package Soenneker.OpenAI.Client.Chat
```

Register:

```
builder.services.AddOpenAIChatClientAsSingleton();
```

`IConfiguration` values:

```
"OpenAI:ApiKey"
"OpenAI:Model"
```

## Usage

```csharp
public class OpenAIService
{
    private readonly IOpenAIChatClient _chatClient;

    public OpenAIService(IOpenAIChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async ValueTask<string> Chat(string prompt, CancellationToken cancellationToken = default)
    {
        var client = await _chatClient.Get(cancellationToken);
        ChatCompletion completion = await client.CompleteChatAsync(prompt);
    }
}
```