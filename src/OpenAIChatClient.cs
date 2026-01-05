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
public sealed class OpenAIChatClient : IOpenAIChatClient
{
    private readonly AsyncSingleton<ChatClient> _client;
    private readonly ILogger<ChatClient> _logger;
    private readonly IConfiguration _configuration;

    private OpenAIClientOptions? _options;
    private string _model;

    public OpenAIChatClient(ILogger<ChatClient> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _client = new AsyncSingleton<ChatClient>(CreateClient);
    }

    private ChatClient CreateClient()
    {
        var apiKey = _configuration.GetValueStrict<string>("OpenAI:ApiKey");
        var model = _configuration.GetValue<string?>("OpenAI:Model");

        if (!_model.IsNullOrEmpty())
            model = _model;

        _logger.LogDebug("Creating OpenAI client with model ({model}) ...", model);

        if (model.IsNullOrEmpty())
        {
            _logger.LogWarning("GPT model has not been set, defaulting to gpt-3.5-turbo");
            model = "gpt-3.5-turbo";
        }

        var credential = new ApiKeyCredential(apiKey);

        var client = new ChatClient(model, credential, _options);

        return client;
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
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
