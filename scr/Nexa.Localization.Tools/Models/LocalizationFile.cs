namespace Nexa.Localization.Tools.Models;

public sealed class LocalizationFile
{
    public string Path { get; init; } = string.Empty;

    public string Culture { get; init; } = string.Empty;

    public string FileName { get; init; } = string.Empty;

    public IReadOnlyDictionary<string, string> Keys { get; init; }
        = new Dictionary<string, string>();
}