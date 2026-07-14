using Microsoft.Extensions.DependencyInjection;
using Nexa.Localization.Abstractions;
using Nexa.Localization.Runtime;

namespace Nexa.Localization.Extensions;

public static class ServiceProviderExtensions
{
    public static async Task InitializeNexaLocalizationAsync(
        this IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        using var scope = serviceProvider.CreateScope();

        var services = scope.ServiceProvider;

        await services
            .GetRequiredService<ILocalizationLoader>()
            .LoadAsync(cancellationToken);

        await services
            .GetRequiredService<ILanguageManager>()
            .InitializeAsync();

        LocalizationRuntime.Current.Initialize(
            services.GetRequiredService<ILocalizationService>());

        services
            .GetRequiredService<ILocalizationValidator>()
            .Validate();
    }
}