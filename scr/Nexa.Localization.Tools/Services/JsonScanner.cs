using Nexa.Localization.Tools.Models;
using System.Text.Json;

namespace Nexa.Localization.Tools.Services;

public sealed class JsonScanner
{
    public IReadOnlyList<LocalizationFile> Scan()
    {
        var result = new List<LocalizationFile>();

        var localizationPath = FindLocalizationFolder();

        if (localizationPath is null)
            return result;

        foreach (var file in Directory.EnumerateFiles(
                     localizationPath,
                     "*.json",
                     SearchOption.AllDirectories))
        {
            var json = File.ReadAllText(file);

            var keys = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                       ?? new Dictionary<string, string>();

            var culture = Path.GetFileName(
                Path.GetDirectoryName(file)!);

            result.Add(new LocalizationFile
            {
                Path = file,
                Culture = culture,
                FileName = Path.GetFileNameWithoutExtension(file),
                Keys = keys
            });
        }

        return result;
    }

    private static string? FindLocalizationFolder()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory is not null)
        {
            var candidate = Path.Combine(
                directory.FullName,
                "Shared",
                "Localization");

            if (Directory.Exists(candidate))
                return candidate;

            directory = directory.Parent;
        }

        return null;
    }
}