using System.Collections.Concurrent;

namespace Nexa.Localization.Caching;

public sealed class LocalizationCache
{
    private readonly ConcurrentDictionary<string, IReadOnlyDictionary<string, string>> _cache =
        new(StringComparer.OrdinalIgnoreCase);

    public int Count => _cache.Count;

    public bool IsEmpty => _cache.IsEmpty;

    public IReadOnlyCollection<string> Cultures
        => _cache.Keys.ToArray();

    public bool ContainsCulture(string culture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);

        return _cache.ContainsKey(culture);
    }

    public bool TryGetCulture(
        string culture,
        out IReadOnlyDictionary<string, string>? values)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);

        return _cache.TryGetValue(culture, out values);
    }

    public IReadOnlyDictionary<string, string>? GetCulture(string culture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);

        _cache.TryGetValue(culture, out var values);

        return values;
    }

    public void SetCulture(
        string culture,
        IReadOnlyDictionary<string, string> values)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);
        ArgumentNullException.ThrowIfNull(values);

        _cache.AddOrUpdate(
            culture,
            values,
            (_, _) => values);
    }

    public void RemoveCulture(string culture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);

        _cache.TryRemove(culture, out _);
    }

    public void Clear()
    {
        _cache.Clear();
    }
}