using Microsoft.Extensions.Options;
using Nexa.Localization.Abstractions;
using Nexa.Localization.Caching;
using Nexa.Localization.Models;
using Nexa.Localization.Exceptions;

namespace Nexa.Localization.Validation;

public sealed class LocalizationValidator : ILocalizationValidator
{
    private readonly LocalizationOptions _options;
    private readonly LocalizationCache _cache;

    public LocalizationValidator(
        IOptions<LocalizationOptions> options,
        LocalizationCache cache)
    {
        _options = options.Value;
        _cache = cache;
    }

    public void Validate()
    {
        ValidateDefaultCulture();

        ValidateFallbackCulture();

        ValidateSupportedLanguages();

        ValidateLoadedCultures();
    }
    private void ValidateDefaultCulture()
    {
        if (!_options.SupportedLanguages.Any(x =>
            x.Code.Equals(_options.DefaultCulture,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidLocalizationConfigurationException(
                $"DefaultCulture '{_options.DefaultCulture}' is not registered.");
        }
    }
    private void ValidateFallbackCulture()
    {
        if (!_options.SupportedLanguages.Any(x =>
            x.Code.Equals(_options.FallbackCulture,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidLocalizationConfigurationException(
                $"FallbackCulture '{_options.FallbackCulture}' is not registered.");
        }
    }
    private void ValidateSupportedLanguages()
    {
        if (_options.SupportedLanguages.Count == 0)
        {
            throw new InvalidLocalizationConfigurationException(
                "No supported languages have been configured.");
        }

        var duplicates = _options.SupportedLanguages
            .GroupBy(x => x.Code, StringComparer.OrdinalIgnoreCase)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .ToList();

        if (duplicates.Count > 0)
        {
            throw new InvalidLocalizationConfigurationException(
                $"Duplicate language(s): {string.Join(", ", duplicates)}");
        }
    }
    private void ValidateLoadedCultures()
    {
        foreach (var language in _options.SupportedLanguages)
        {
            if (!_cache.ContainsCulture(language.Code))
            {
                throw new InvalidLocalizationConfigurationException(
                    $"Localization resources for culture '{language.Code}' were not found. Ensure that JSON localization files exist and are included in the project.");
            }
        }
    }
}