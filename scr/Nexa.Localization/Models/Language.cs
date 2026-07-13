namespace Nexa.Localization.Models;

public sealed class Language
{
    /// <summary>
    /// ISO Code (ku, en, ar...)
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// English Name
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Native Name
    /// </summary>
    public required string NativeName { get; init; }

    /// <summary>
    /// Flag Emoji or Icon
    /// </summary>
    public string Flag { get; init; } = string.Empty;

    /// <summary>
    /// RTL Support
    /// </summary>
    public bool IsRightToLeft { get; init; }

    /// <summary>
    /// Enabled / Disabled
    /// </summary>
    public bool Enabled { get; init; } = true;
}