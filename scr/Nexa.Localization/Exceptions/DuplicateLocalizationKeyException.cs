namespace Nexa.Localization.Exceptions;

public sealed class DuplicateLocalizationKeyException : LocalizationException
{
    public string Culture { get; }

    public string Key { get; }

    public DuplicateLocalizationKeyException(string culture, string key)
        : base($"Duplicate localization key '{key}' detected for culture '{culture}'.")
    {
        Culture = culture;
        Key = key;
    }
}