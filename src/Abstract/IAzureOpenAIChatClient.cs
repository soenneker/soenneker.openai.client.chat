using OpenAI;
using OpenAI.Chat;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.OpenAI.Client.Chat.Abstract;

/// <summary>
/// An async thread-safe singleton for the Azure OpenAI Chat (completions) client
/// </summary>
// ReSharper disable once InconsistentNaming
public interface IAzureOpenAIChatClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Not required, but can be used to set the model and options for the client
    /// </summary>
    /// <param name="model"></param>
    /// <param name="options"></param>
    void SetOptions(string model, OpenAIClientOptions options);

    ValueTask<ChatClient> Get(CancellationToken cancellationToken = default);
}
