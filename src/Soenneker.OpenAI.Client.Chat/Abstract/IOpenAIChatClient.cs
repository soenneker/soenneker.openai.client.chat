using OpenAI;
using OpenAI.Chat;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Soenneker.OpenAI.Client.Chat.Abstract;

/// <summary>
/// An async thread-safe singleton for the OpenAI Chat (completions) client
/// </summary>
// ReSharper disable once InconsistentNaming
/// <summary>
/// Defines the open ai chat client contract.
/// </summary>
public interface IOpenAIChatClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Not required, but can be used to set the model and options for the client
    /// </summary>
    /// <param name="model"></param>
    /// <param name="options"></param>
    void SetOptions(string model, OpenAIClientOptions options);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ChatClient> Get(CancellationToken cancellationToken = default);
}
