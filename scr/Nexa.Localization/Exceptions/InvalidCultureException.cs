namespace Nexa.Localization.Exceptions;

public sealed class InvalidCultureException : LocalizationException
{
    public string Culture { get; }

    public InvalidCultureException(string culture)
        : base($"The culture '{culture}' is invalid.")
    {
        Culture = culture;
    }
}