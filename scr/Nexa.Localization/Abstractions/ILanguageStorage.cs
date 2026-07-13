namespace Nexa.Localization.Abstractions;

public interface ILanguageStorage
{
    Task<string?> GetAsync(string key);

    Task SetAsync(string key, string value);

    Task RemoveAsync(string key);

    Task ClearAsync();
}