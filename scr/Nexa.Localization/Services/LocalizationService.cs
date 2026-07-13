using Nexa.Localization.Abstractions;
using Nexa.Localization.Models;

namespace Nexa.Localization.Services;

public sealed class LocalizationService : ILocalizationService
{
    private readonly ILocalizationProvider _provider;
    private readonly ILanguageManager _languageManager;

    public LocalizationService(
        ILocalizationProvider provider,
        ILanguageManager languageManager)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(languageManager);

        _provider = provider;
        _languageManager = languageManager;
    }

    public string CurrentCulture
        => _languageManager.CurrentCulture;

    public Language CurrentLanguage
        => _languageManager.CurrentLanguage;

    public string this[string key]
        => Get(key);

    public string this[string key, params object[] args]
        => Get(key, args);

    public event Action? CultureChanged
    {
        add => _languageManager.LanguageChanged += value;
        remove => _languageManager.LanguageChanged -= value;
    }

    public string Get(string key)
        => _provider.GetString(_languageManager.CurrentCulture, key);

    public string Get(string key, params object[] args)
        => _provider.GetString(_languageManager.CurrentCulture, key, args);

    public bool TryGet(string key, out string value)
        => _provider.TryGetString(_languageManager.CurrentCulture, key, out value);

    public bool ContainsKey(string key)
        => _provider.TryGetString(_languageManager.CurrentCulture, key, out _);
}