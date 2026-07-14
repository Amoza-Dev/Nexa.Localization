using Nexa.Localization.Abstractions;
using Nexa.Localization.Models;

namespace Nexa.Localization.Runtime;

public sealed class LocalizationRuntime
{
    public static LocalizationRuntime Current { get; } = new();

    private ILocalizationService? _localization;

    internal void Initialize(ILocalizationService localization)
    {
        _localization = localization;
    }

    public string Get(LocalizationKey key)
    {
        if (_localization is null)
            return key.Key;

        return _localization[key.Key];
    }
}