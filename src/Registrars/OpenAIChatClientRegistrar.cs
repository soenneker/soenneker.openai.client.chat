using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Client.Chat.Abstract;
// ReSharper disable InconsistentNaming

namespace Soenneker.OpenAI.Client.Chat.Registrars;

/// <summary>
/// An async thread-safe singleton for the OpenAI Chat (completions) client
/// </summary>
public static class OpenAIChatClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IOpenAIChatClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddOpenAIChatClientAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IOpenAIChatClient, OpenAIChatClient>();
    }

    /// <summary>
    /// Adds <see cref="IOpenAIChatClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddOpenAIChatClientAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IOpenAIChatClient, OpenAIChatClient>();
    }
}
