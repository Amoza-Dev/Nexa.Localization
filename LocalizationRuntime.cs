using Nexa.Localization.Abstractions;

namespace Nexa.Localization.Runtime;

public sealed class LocalizationRuntime
{
    public static LocalizationRuntime Current { get; } = new();

    private ILocalizationService? _service;

    internal void Initialize(ILocalizationService service)
    {
        _service = service;
    }

    public string Get(LocalizationKey key)
    {
        if (_service is null)
            return key.Key;

        return _service[key.Key];
    }
}