using Nexa.Localization.Runtime;

namespace Nexa.Localization.Models;

public sealed class LocalizationKey
{
    public string Key { get; }

    public LocalizationKey(string key)
    {
        Key = key;
    }

    public override string ToString()
    {
        return LocalizationRuntime.Current.Get(this);
    }

    public static implicit operator string(LocalizationKey key)
        => key.ToString();
}