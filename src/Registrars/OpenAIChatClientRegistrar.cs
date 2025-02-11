using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Client.Chat.Abstract;

namespace Soenneker.OpenAI.Client.Chat.Registrars
{
    /// <summary>
    /// An async thread-safe singleton for the OpenAI Chat (completions) client
    /// </summary>
    public static class OpenAIChatClientRegistrar
    {
        /// <summary>
        /// Adds <see cref="IOpenAIChatClient"/> as a singleton service. <para/>
        /// </summary>
        public static IServiceCollection AddOpenAIChatClientAsSingleton(this IServiceCollection services)
        {
            services.TryAddSingleton<IOpenAIChatClient, OpenAIChatClient>();
            return services;
        }

        /// <summary>
        /// Adds <see cref="IOpenAIChatClient"/> as a scoped service. <para/>
        /// </summary>
        public static IServiceCollection AddOpenAIChatClientAsScoped(this IServiceCollection services)
        {
            services.TryAddScoped<IOpenAIChatClient, OpenAIChatClient>();
            return services;
        }
    }
}