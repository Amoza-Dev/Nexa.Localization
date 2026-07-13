using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nexa.Localization.SourceGenerator.Generators;
using System.Collections.Immutable;
using System.Linq;

namespace Nexa.Localization.Tests.Generators;

internal static class GeneratorTestHelper
{
    public static GeneratorTestResult Run(
        params InMemoryAdditionalText[] files)
    {
        var compilation = CSharpCompilation.Create(
            assemblyName: "Tests",
            syntaxTrees:
            [
                CSharpSyntaxTree.ParseText(
                    """
                    public class Dummy
                    {
                    }
                    """)
            ],
            references:
            [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
            ],
            options: new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary));

        var generator = new LocalizationIncrementalGenerator();

        GeneratorDriver driver =
            CSharpGeneratorDriver.Create(
                [generator.AsSourceGenerator()],
                additionalTexts: files);

        driver = driver.RunGenerators(compilation);

        var result = driver.GetRunResult();

        var generated =
            result.Results
                  .SelectMany(r => r.GeneratedSources)
                  .FirstOrDefault()
                  .SourceText?
                  .ToString()
            ?? string.Empty;

        var diagnostics =
            result.Results
                  .SelectMany(r => r.Diagnostics)
                  .ToImmutableArray();

        return new GeneratorTestResult(
            generated,
            diagnostics);
    }
}