using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nexa.Localization.Abstractions;
using Nexa.Localization.Caching;
using Nexa.Localization.Models;
using Nexa.Localization.Providers;
using Nexa.Localization.Services;
using Nexa.Localization.Storage;
using Nexa.Localization.Validation;

namespace Nexa.Localization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNexatLocalization(
        this IServiceCollection services,
        Action<LocalizationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        if (configure is not null)
            services.Configure(configure);

        services.TryAddSingleton<LocalizationCache>();

        services.TryAddSingleton<ILanguageManager, LanguageManager>();

        services.TryAddSingleton<ILocalizationLoader, JsonLocalizationLoader>();

        services.TryAddSingleton<ILocalizationProvider, JsonLocalizationProvider>();

        services.TryAddSingleton<ILocalizationService, LocalizationService>();

        services.AddSingleton<ILanguageStorage, MemoryLanguageStorage>();
        
        services.TryAddSingleton<ILanguagePersistence, LanguagePersistenceService>();
     
        services.AddSingleton<ILocalizationValidator, LocalizationValidator>();

        return services;
    }
}