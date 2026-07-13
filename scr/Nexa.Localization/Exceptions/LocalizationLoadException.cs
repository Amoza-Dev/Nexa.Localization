namespace Nexa.Localization.Exceptions;

public sealed class LocalizationLoadException : LocalizationException
{
    public LocalizationLoadException(string message)
        : base(message)
    {
    }

    public LocalizationLoadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}