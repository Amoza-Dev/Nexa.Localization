using System;

namespace Nexa.Localization.SourceGenerator.Common;

internal static class LocalizationPath
{
    public static string Normalize(string path)
    {
        return path.Replace('\\', '/');
    }

    public static string GetCulture(string path)
    {
        var normalizedPath = Normalize(path);

        // Shared/Localization/ar/buttons.json
        var parts = normalizedPath.Split('/');

        if (parts.Length >= 2)
            return parts[parts.Length - 2];

        // Nexa.Localization.SourceGenerator.DefaultJson.ar.buttons.json
        var resourceParts = path.Split('.');

        var index = Array.IndexOf(resourceParts, "DefaultJson");

        if (index >= 0 && index + 1 < resourceParts.Length)
            return resourceParts[index + 1];

        return string.Empty;
    }
}