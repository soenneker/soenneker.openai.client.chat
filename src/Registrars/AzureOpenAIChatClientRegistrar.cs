using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Client.Chat.Abstract;
// ReSharper disable InconsistentNaming

namespace Soenneker.OpenAI.Client.Chat.Registrars;

/// <summary>
/// An async thread-safe singleton for the Azure OpenAI Chat (completions) client
/// </summary>
public static class AzureOpenAIChatClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IAzureOpenAIChatClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddAzureOpenAIChatClientAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IAzureOpenAIChatClient, AzureOpenAIChatClient>();
    }

    /// <summary>
    /// Adds <see cref="IAzureOpenAIChatClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddAzureOpenAIChatClientAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IAzureOpenAIChatClient, AzureOpenAIChatClient>();
    }
}
