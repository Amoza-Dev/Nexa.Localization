using System.Text.Json;

var localizationPath =
    @"C:\Users\ahmed\Downloads\KRD.Localization-master\KRD.Localization-master\scr\Nexa.Localization\Shared\Localization";

var files = Directory.GetFiles(
    localizationPath,
    "*.json", 
    SearchOption.AllDirectories);

var totalKeys = 0;

var cultureStatistics = new Dictionary<string, (int Files, int Keys)>(
    StringComparer.OrdinalIgnoreCase);

// لێرەدا تەنها کلیلەکانی یەک زمان پاشەکەوت دەکەین بۆ پیشاندان
var uniqueFilesData = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
string? firstCultureFound = null;

foreach (var file in files)
{
    var json = File.ReadAllText(file);

    var values = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                 ?? new Dictionary<string, string>();

    totalKeys += values.Count;

    var culture = Path.GetFileName(Path.GetDirectoryName(file)!);
    var fileName = Path.GetFileName(file);

    // ١. کۆکردنەوەی ئاماری هەموو زمانەکان
    if (!cultureStatistics.TryGetValue(culture, out var stats))
    {
        stats = (0, 0);
    }
    stats.Files++;
    stats.Keys += values.Count;
    cultureStatistics[culture] = stats;

    // ٢. دیاریکردنی یەکەم زمان بۆ ئەوەی تەنها کلیلەکانی ئەو پیشان بدەین
    if (firstCultureFound == null)
    {
        firstCultureFound = culture;
    }

    // تەنها ئەگەر فۆڵدەرەکە زمانی یەکەم بێت، کلیلەکانی کۆدەکەینەوە
    if (string.Equals(culture, firstCultureFound, StringComparison.OrdinalIgnoreCase))
    {
        uniqueFilesData[fileName] = values.Keys.ToList();
    }
}

Console.WriteLine();
Console.WriteLine("==============================================");
Console.WriteLine("        Nexa.Localization Resource Library");
Console.WriteLine("==============================================");
Console.WriteLine();

Console.WriteLine($"Cultures : {cultureStatistics.Count}");
Console.WriteLine($"Files    : {files.Length}");
Console.WriteLine($"Keys     : {totalKeys}");
Console.WriteLine($"Average  : {(files.Length > 0 ? (double)totalKeys / files.Length : 0):F1} Keys/File");

Console.WriteLine();
Console.WriteLine("By Culture");
Console.WriteLine("----------------------------------------------");

foreach (var culture in cultureStatistics.OrderBy(x => x.Key))
{
    Console.WriteLine(
        $"{culture.Key,-5} Files: {culture.Value.Files,-3} Keys: {culture.Value.Keys}");
}

Console.WriteLine();
Console.WriteLine("==============================================");
Console.WriteLine($"      Available Keys Preview      ");
Console.WriteLine("==============================================");

// لێرەدا تەنها یەکجار بەپێی ناوی فایلەکان کلیلەکان چاپ دەکەین
foreach (var fileData in uniqueFilesData.OrderBy(x => x.Key))
{
    Console.WriteLine();
    Console.WriteLine($"  File: {fileData.Key} ({fileData.Value.Count} Keys)");
    Console.WriteLine("----------------------------------------------");

    foreach (var key in fileData.Value)
    {
        Console.WriteLine($"   🔹 {key}");
    }
}

Console.WriteLine();
Console.WriteLine("==============================================");