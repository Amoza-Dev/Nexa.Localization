using Nexa.Localization.Models;

public interface ILanguageManager
{
    Language CurrentLanguage { get; }

    string CurrentCulture { get; }

    bool IsRightToLeft { get; }

    IReadOnlyList<Language> SupportedLanguages { get; }

    event Action? LanguageChanged;

    void SetLanguage(string culture);

    Task InitializeAsync(CancellationToken cancellationToken = default);
}