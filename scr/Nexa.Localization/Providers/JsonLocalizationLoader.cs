using Nexa.Localization.Abstractions;
using Nexa.Localization.Caching;
using Nexa.Localization.Exceptions;
using Nexa.Localization.Helpers;

namespace Nexa.Localization.Providers;

public sealed class JsonLocalizationLoader : ILocalizationLoader
{
    private readonly LocalizationCache _cache;

    public JsonLocalizationLoader(LocalizationCache cache)
    {
        ArgumentNullException.ThrowIfNull(cache);

        _cache = cache;
    }

    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var assembly = typeof(JsonLocalizationLoader).Assembly;

            var resources = assembly
                .GetManifestResourceNames()
                .Where(x => x.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x)
                .ToArray();

            if (resources.Length == 0)
                return;

            var cultures = new Dictionary<string, Dictionary<string, string>>(
                StringComparer.OrdinalIgnoreCase);

            foreach (var resource in resources)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await using var stream = assembly.GetManifestResourceStream(resource);

                if (stream is null)
                    continue;

                using var reader = new StreamReader(stream);

                var json = await reader.ReadToEndAsync(cancellationToken);

                if (string.IsNullOrWhiteSpace(json))
                    continue;

                var items = JsonHelper.Read(json);

                if (items.Count == 0)
                    continue;

                var parts = resource.Split('.');

                var localizationIndex = Array.FindLastIndex(
                    parts,
                    p => p.Equals("Localization", StringComparison.OrdinalIgnoreCase));

                if (localizationIndex < 0 || localizationIndex + 1 >= parts.Length)
                    continue;

                var culture = parts[localizationIndex + 1];

                if (!cultures.TryGetValue(culture, out var values))
                {
                    values = new Dictionary<string, string>(
                        StringComparer.OrdinalIgnoreCase);

                    cultures.Add(culture, values);
                }

                foreach (var item in items)
                {
                    if (values.ContainsKey(item.Key))
                    {
                        throw new DuplicateLocalizationKeyException(
                            culture,
                            item.Key);
                    }

                    values.Add(item.Key, item.Value);
                }
            }

            foreach (var culture in cultures)
            {
                cancellationToken.ThrowIfCancellationRequested();

                _cache.SetCulture(culture.Key, culture.Value);
            }
        }
        catch (LocalizationException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new LocalizationLoadException(
                "Failed to load localization resources.",
                ex);
        }
    }
}