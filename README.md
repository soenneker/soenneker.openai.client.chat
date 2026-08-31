[![](https://img.shields.io/nuget/v/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.client.chat/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.client.chat/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.client.chat.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.client.chat/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.client.chat/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.openai.client.chat/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenAI.Client.Chat

Creates and caches an `OpenAI.Chat.ChatClient` from application configuration.

For the Azure version of this: [Soenneker.Azure.OpenAI.Client.Chat](https://github.com/soenneker/soenneker.azure.openai.client.chat)

## Installation

```bash
dotnet add package Soenneker.OpenAI.Client.Chat
```

## Configuration

```json
{
  "OpenAI": {
    "ApiKey": "your-api-key",
    "Model": "your-chat-model"
  }
}
```

## Usage

```csharp
using OpenAI.Chat;
using Soenneker.OpenAI.Client.Chat.Abstract;
using Soenneker.OpenAI.Client.Chat.Registrars;

services.AddOpenAIChatClientAsSingleton();

IOpenAIChatClient provider = serviceProvider
    .GetRequiredService<IOpenAIChatClient>();

ChatClient client = await provider.Get(cancellationToken);
ChatCompletion completion = await client.CompleteChatAsync(
    prompt,
    cancellationToken: cancellationToken);

string text = completion.Content.Count > 0
    ? completion.Content[0].Text
    : string.Empty;
```

`Get()` creates the client once and returns the cached instance thereafter. If you need to supply `OpenAIClientOptions` or override the configured model, call `SetOptions(...)` before the first call to `Get()`:

```csharp
provider.SetOptions(model, new OpenAIClientOptions
{
    Endpoint = new Uri("https://your-compatible-endpoint.example/v1")
});
```

Changing options after the client has been created does not replace the cached client.
