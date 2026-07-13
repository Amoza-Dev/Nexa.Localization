using Nexa.Localization.Abstractions;

namespace Nexa.Localization.Services;

public sealed class LanguagePersistenceService : ILanguagePersistence
{
    private readonly ILanguageStorage _storage;

    private const string StorageKey = "Nexa.Localization.Language";
    public LanguagePersistenceService(ILanguageStorage storage)
    {
        _storage = storage;
    }

    public Task<string?> LoadAsync()
    {
        return _storage.GetAsync(StorageKey);
    }

    public Task SaveAsync(string culture)
    {
        return _storage.SetAsync(StorageKey, culture);
    }

    public Task ClearAsync()
    {
        return _storage.RemoveAsync(StorageKey);
    }
}