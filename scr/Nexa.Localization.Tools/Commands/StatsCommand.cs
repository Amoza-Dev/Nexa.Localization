using System.CommandLine;
using Nexa.Localization.Tools.Services;

namespace Nexa.Localization.Tools.Commands;

public static class StatsCommand
{
    public static Command Create()
    {
        var command = new Command(
            "stats",
            "Show localization statistics");

        command.SetHandler(() =>
        {
            var files = new JsonScanner().Scan();

            if (files.Count == 0)
            {
                System.Console.WriteLine("No localization files found.");
                return;
            }

            var totalKeys = files.Sum(f => f.Keys.Count);

            var cultures = files
                .Select(f => f.Culture)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => c)
                .ToList();

            System.Console.WriteLine("Nexa.Localization Statistics");
            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine($"Files     : {files.Count}");
            System.Console.WriteLine($"Cultures  : {cultures.Count}");
            System.Console.WriteLine($"Keys      : {totalKeys}");
            System.Console.WriteLine();

            foreach (var culture in cultures)
            {
                var cultureFiles = files.Where(f =>
                    string.Equals(
                        f.Culture,
                        culture,
                        StringComparison.OrdinalIgnoreCase));

                var fileCount = cultureFiles.Count();
                var keyCount = cultureFiles.Sum(f => f.Keys.Count);

                System.Console.WriteLine(
                    $"{culture,-5} Files: {fileCount,-3} Keys: {keyCount}");
            }
        });

        return command;
    }
}