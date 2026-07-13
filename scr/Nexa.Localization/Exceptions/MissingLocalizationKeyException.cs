namespace Nexa.Localization.Exceptions;

public sealed class MissingLocalizationKeyException : LocalizationException
{
    public string Culture { get; }

    public string Key { get; }

    public MissingLocalizationKeyException(string culture, string key)
        : base($"Localization key '{key}' was not found for culture '{culture}'.")
    {
        Culture = culture;
        Key = key;
    }
}