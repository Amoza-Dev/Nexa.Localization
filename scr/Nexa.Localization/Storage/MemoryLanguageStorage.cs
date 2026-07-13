using Nexa.Localization.Abstractions;
using System.Collections.Concurrent;

namespace Nexa.Localization.Storage;

public sealed class MemoryLanguageStorage : ILanguageStorage
{
    private readonly ConcurrentDictionary<string, string> _storage =
        new(StringComparer.OrdinalIgnoreCase);

    public Task<string?> GetAsync(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        _storage.TryGetValue(key, out var value);

        return Task.FromResult<string?>(value);
    }

    public Task SetAsync(string key, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        _storage[key] = value;

        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        _storage.TryRemove(key, out _);

        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        _storage.Clear();

        return Task.CompletedTask;
    }
}