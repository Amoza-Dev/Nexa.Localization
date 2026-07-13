using Microsoft.Extensions.Options;
using Nexa.Localization.Abstractions;
using Nexa.Localization.Caching;
using Nexa.Localization.Exceptions;
using Nexa.Localization.Models;

public sealed class JsonLocalizationProvider : ILocalizationProvider
{
    private readonly LocalizationCache _cache;
    private readonly LocalizationOptions _options;

    public JsonLocalizationProvider(
        LocalizationCache cache,
        IOptions<LocalizationOptions> options)
    {
        ArgumentNullException.ThrowIfNull(cache);
        ArgumentNullException.ThrowIfNull(options);

        _cache = cache;
        _options = options.Value;
    }

    public string GetString(string culture, string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        if (TryGetString(culture, key, out var value))
            return value;

        if (!culture.Equals(_options.FallbackCulture, StringComparison.OrdinalIgnoreCase) &&
            TryGetString(_options.FallbackCulture, key, out value))
        {
            return value;
        }

        if (_options.ThrowIfKeyNotFound)
        {
            throw new MissingLocalizationKeyException(culture, key);
        }

        return key;
    }

    public string GetString(
        string culture,
        string key,
        params object[] arguments)
    {
        var format = GetString(culture, key);

        return arguments.Length == 0
            ? format
            : string.Format(
                System.Globalization.CultureInfo.GetCultureInfo(culture),
                format,
                arguments);
    }

    public bool TryGetString(
        string culture,
        string key,
        out string value)
    {
        value = string.Empty;

        if (!_cache.TryGetCulture(culture, out var dictionary) ||
            dictionary is null)
        {
            return false;
        }

        return dictionary.TryGetValue(key, out value!);
    }
}