using Microsoft.Extensions.DependencyInjection;

namespace Nexa.Localization.Blazor.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNexaLocalizationBlazor(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services;
    }
}