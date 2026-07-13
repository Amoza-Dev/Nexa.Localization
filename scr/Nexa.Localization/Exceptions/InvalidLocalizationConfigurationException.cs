namespace Nexa.Localization.Exceptions;

public sealed class InvalidLocalizationConfigurationException : LocalizationException
{
    public InvalidLocalizationConfigurationException(string message)
        : base(message)
    {
    }
}