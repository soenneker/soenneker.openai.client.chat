using Soenneker.OpenAI.Client.Chat.Abstract;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Utils.AsyncSingleton;
using OpenAI.Chat;
using Soenneker.Extensions.Configuration;
using OpenAI;
using System.ClientModel;
using Soenneker.Extensions.String;
// ReSharper disable InconsistentNaming

namespace Soenneker.OpenAI.Client.Chat;

/// <inheritdoc cref="IOpenAIChatClient"/>
public class OpenAIChatClient : IOpenAIChatClient
{
    private readonly AsyncSingleton<ChatClient> _client;

    private OpenAIClientOptions? _options;
    private string _model;

    public OpenAIChatClient(ILogger<ChatClient> logger, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ChatClient>(() =>
        {
            var apiKey = configuration.GetValueStrict<string>("OpenAI:ApiKey");
            var model = configuration.GetValue<string?>("OpenAI:Model");

            if (!_model.IsNullOrEmpty())
                model = _model;

            logger.LogDebug("Creating OpenAI client with model ({model}) ...", model);

            if (model.IsNullOrEmpty())
            {
                logger.LogWarning("GPT model has not been set, defaulting to gpt-3.5-turbo");
                model = "gpt-3.5-turbo";
            }

            var credential = new ApiKeyCredential(apiKey);

            var client = new ChatClient(model, credential, _options);

            return client;
        });

    }

    public void SetOptions(string model, OpenAIClientOptions options)
    {
        _model = model;
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
