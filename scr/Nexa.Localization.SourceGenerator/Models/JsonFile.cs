using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Models;

public sealed class JsonFile
{
    public string Path { get; }

    public string Culture { get; }

    public IReadOnlyDictionary<string, string> Values { get; }

    public JsonFile(
        string path,
        string culture,
        IReadOnlyDictionary<string, string> values)
    {
        Path = path;
        Culture = culture;
        Values = values;
    }
}