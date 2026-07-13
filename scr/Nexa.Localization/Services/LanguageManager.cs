using Microsoft.Extensions.Options;
using Nexa.Localization.Abstractions;
using Nexa.Localization.Exceptions;
using Nexa.Localization.Models;
using System.Globalization;

namespace Nexa.Localization.Services;

public sealed class LanguageManager : ILanguageManager
{
    private readonly LocalizationOptions _options;
    private readonly ILanguagePersistence _languagePersistence;

    private Language _currentLanguage;

    public LanguageManager(IOptions<LocalizationOptions> options,
        ILanguagePersistence languagePersistence)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(languagePersistence);

        _options = options.Value;
        _languagePersistence = languagePersistence;

        _currentLanguage =
            _options.SupportedLanguages.FirstOrDefault(x =>
                x.Code.Equals(_options.DefaultCulture, StringComparison.OrdinalIgnoreCase))
            ??
            _options.SupportedLanguages.FirstOrDefault()
            ??
            throw new InvalidOperationException(
                "No supported languages have been configured.");

        ApplyCulture(_currentLanguage.Code);
        _languagePersistence = languagePersistence;
    }

    public Language CurrentLanguage => _currentLanguage;

    public string CurrentCulture => _currentLanguage.Code;

    public bool IsRightToLeft => _currentLanguage.IsRightToLeft;

    public IReadOnlyList<Language> SupportedLanguages
        => _options.SupportedLanguages.AsReadOnly();

    public event Action? LanguageChanged;

    public void SetLanguage(string culture)
    {
        if (string.IsNullOrWhiteSpace(culture))
            throw new ArgumentNullException(nameof(culture));

        culture = culture.Trim().ToLowerInvariant();

        var language = GetLanguage(culture);

        if (language is null)
            throw new LanguageNotFoundException(culture);

        if (_currentLanguage.Code.Equals(language.Code,
                StringComparison.OrdinalIgnoreCase))
            return;

        _currentLanguage = language;

        ApplyCulture(language.Code);

        LanguageChanged?.Invoke();
        _ = _languagePersistence.SaveAsync(language.Code);
    }

    public bool TrySetLanguage(string culture)
    {
        if (!IsSupportedLanguage(culture))
            return false;

        SetLanguage(culture);

        return true;
    }

    public bool IsSupportedLanguage(string culture)
    {
        if (string.IsNullOrWhiteSpace(culture))
            return false;

        culture = culture.Trim().ToLowerInvariant();

        return _options.SupportedLanguages.Any(x =>
            x.Code.Equals(culture, StringComparison.OrdinalIgnoreCase));
    }

    public Language? GetLanguage(string culture)
    {
        if (string.IsNullOrWhiteSpace(culture))
            return null;

        culture = culture.Trim().ToLowerInvariant();

        return _options.SupportedLanguages.FirstOrDefault(x =>
            x.Code.Equals(culture, StringComparison.OrdinalIgnoreCase));
    }

    public void ResetToDefault()
    {
        SetLanguage(_options.DefaultCulture);
    }

    private static void ApplyCulture(string culture)
    {
        var cultureInfo = new CultureInfo(culture);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var culture = await _languagePersistence.LoadAsync();

        if (string.IsNullOrWhiteSpace(culture))
            return;

        if (IsSupportedLanguage(culture))
        {
            SetLanguage(culture);
        }
    }
}