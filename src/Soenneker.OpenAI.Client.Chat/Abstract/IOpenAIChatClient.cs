using OpenAI;
using OpenAI.Chat;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.OpenAI.Client.Chat.Abstract;

/// <summary>
/// Creates and caches an OpenAI chat client.
/// </summary>
// ReSharper disable once InconsistentNaming
public interface IOpenAIChatClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Sets the model and client options to use when the client is first created.
    /// </summary>
    /// <param name="model">Model identifier.</param>
    /// <param name="options">OpenAI client options.</param>
    /// <remarks>Call this before <see cref="Get"/>. It does not replace an already-created client.</remarks>
    void SetOptions(string model, OpenAIClientOptions options);

    /// <summary>
    /// Gets the cached chat client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured chat client.</returns>
    ValueTask<ChatClient> Get(CancellationToken cancellationToken = default);
}
