using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nexa.Localization.SourceGenerator.Builders;
using Nexa.Localization.SourceGenerator.CodeGeneration;
using Nexa.Localization.SourceGenerator.Diagnostics;
using Nexa.Localization.SourceGenerator.Models;
using Nexa.Localization.SourceGenerator.Parsing;
using Nexa.Localization.SourceGenerator.Validation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Nexa.Localization.SourceGenerator.Generators;

[Generator]
public sealed class LocalizationIncrementalGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var jsonFiles = context.AdditionalTextsProvider
            .Where(static file => file.Path.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            .Collect();

        context.RegisterSourceOutput(
            jsonFiles,
            static (productionContext, files) =>
            {
                Execute(productionContext, files);
            });
    }

    private static void Execute(
        SourceProductionContext context,
        ImmutableArray<AdditionalText> files)
    {
        var parsedFiles = new List<JsonFile>();

        // یەکەم: JSON ـەکانی Framework
        //parsedFiles.AddRange(DefaultJsonReader.Read());

        foreach (var file in files)
        {
            var text = file.GetText(context.CancellationToken);

            if (text is null)
                continue;

            try
            {
                parsedFiles.Add(
                    JsonParser.Parse(
                        file.Path,
                        text.ToString()));
            }
            catch (JsonException ex)
            {
                InvalidJsonDiagnostic.Report(
                    context,
                    Location.None,
                    ex.Message);
            }
        }

        LocalizationValidator.Validate(
            context,
            parsedFiles);

        var tree = new LocalizationTreeBuilder()
            .Build(parsedFiles);

        var source = new CSharpCodeGenerator()
            .Generate(tree);

        context.AddSource(
            "Nexa.g.cs",
            SourceText.From(source, Encoding.UTF8));
    }
}