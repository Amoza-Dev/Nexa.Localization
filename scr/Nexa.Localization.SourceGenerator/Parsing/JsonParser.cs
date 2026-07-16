using Nexa.Localization.SourceGenerator.Common;
using Nexa.Localization.SourceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Nexa.Localization.SourceGenerator.Parsing;

public static class JsonParser
{
    public static JsonFile Parse(string path, string json)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        if (json == null)
            throw new ArgumentNullException(nameof(json));

        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using var document = JsonDocument.Parse(json);

        if (document.RootElement.ValueKind != JsonValueKind.Object)
        {
            throw new JsonException(
                $"Localization file '{path}' must contain a JSON object.");
        }

        foreach (var property in document.RootElement.EnumerateObject())
        {
            if (property.Value.ValueKind != JsonValueKind.String)
                continue;

            values[property.Name] = property.Value.GetString() ?? string.Empty;
        }

        var normalizedPath = LocalizationPath.Normalize(path);

        var culture = LocalizationPath.GetCulture(normalizedPath);

        return new JsonFile(
            normalizedPath,
            culture,
            values);
    }
}