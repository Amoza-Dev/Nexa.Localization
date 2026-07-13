namespace Nexa.Localization.Abstractions;

public interface ILanguagePersistence
{
    Task<string?> LoadAsync();

    Task SaveAsync(string culture);

    Task ClearAsync();
}