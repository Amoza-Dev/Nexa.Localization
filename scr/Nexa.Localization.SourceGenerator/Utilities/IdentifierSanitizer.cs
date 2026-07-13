using System.Text;

namespace Nexa.Localization.SourceGenerator.Utilities;

internal static class IdentifierSanitizer
{
    public static string Sanitize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "_";

        var builder = new StringBuilder();

        var upper = true;

        foreach (var ch in value)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                upper = true;
                continue;
            }

            if (builder.Length == 0 && char.IsDigit(ch))
            {
                builder.Append('_');
            }

            builder.Append(
                upper
                    ? char.ToUpperInvariant(ch)
                    : ch);

            upper = false;
        }

        return builder.Length == 0
            ? "_"
            : builder.ToString();
    }
}