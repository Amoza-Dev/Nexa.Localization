namespace Nexa.Localization.Exceptions;

public sealed class LanguageNotFoundException : LocalizationException
{
    public string Culture { get; }

    public LanguageNotFoundException(string culture)
        : base($"The language '{culture}' is not registered.")
    {
        Culture = culture;
    }
}