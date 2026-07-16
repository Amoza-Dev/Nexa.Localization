using System.Text.RegularExpressions;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class LocalizationKeyValidator
{
    private static readonly Regex Regex = new(
        @"^(?:[a-z][a-z0-9]*)(?:\.[A-Za-z][A-Za-z0-9]*)*$",
        RegexOptions.Compiled);

    public static bool IsValid(string key)
    {
        return Regex.IsMatch(key);
    }
}