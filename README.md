[![](https://img.shields.io/nuget/v/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.client.chat/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.client.chat/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenAI.Client.Chat
### An async thread-safe singleton for the Azure OpenAI Chat (completions) client

This library provides an implementation for interacting with Azure's OpenAI service. It allows you to configure and utilize a ChatClient to perform various tasks using OpenAI's models.

## Installation

```
dotnet add package Soenneker.OpenAI.Client.Chat
```

Register:

```
builder.services.AddAzureOpenAIChatClientAsSingleton();
```

`IConfiguration` values:

```
"Azure:OpenAI:Deployment"
"Azure:OpenAI:ApiKey"
"Azure:OpenAI:Uri"
```

## Usage

```csharp
public class OpenAIService
{
    private readonly IAzureOpenAIChatClient _chatClient;

    public OpenAIService(IAzureOpenAIChatClient chatClient)
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