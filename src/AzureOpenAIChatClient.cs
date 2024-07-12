using Soenneker.OpenAI.Client.Chat.Abstract;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Utils.AsyncSingleton;
using OpenAI.Chat;
using Soenneker.Extensions.Configuration;
using System.ClientModel;
using Soenneker.Extensions.String;
using Azure.AI.OpenAI;

// ReSharper disable InconsistentNaming

namespace Soenneker.OpenAI.Client.Chat;

/// <inheritdoc cref="IAzureOpenAIChatClient"/>
public class AzureOpenAIChatClient : IAzureOpenAIChatClient
{
    private readonly AsyncSingleton<ChatClient> _client;

    private AzureOpenAIClientOptions? _options;
    private string _deployment;

    public AzureOpenAIChatClient(ILogger<ChatClient> logger, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ChatClient>(() =>
        {
            var uri = configuration.GetValueStrict<string>("Azure:OpenAI:Uri");
            var apiKey = configuration.GetValueStrict<string>("Azure:OpenAI:ApiKey");
            var deployment = configuration.GetValue<string?>("Azure:OpenAI:Deployment");

            if (!_deployment.IsNullOrEmpty())
                deployment = _deployment;

            logger.LogDebug("Creating Azure OpenAI client with deployment ({deployment})...", deployment);

            var credential = new ApiKeyCredential(apiKey);

            var azureClient = new AzureOpenAIClient(new Uri(uri), credential, _options);

            ChatClient? client = azureClient.GetChatClient(deployment);

            return client;
        });
    }

    public void SetOptions(string model, AzureOpenAIClientOptions options)
    {
        _deployment = model;
        _options = options;
    }

    public ValueTask<ChatClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }
}