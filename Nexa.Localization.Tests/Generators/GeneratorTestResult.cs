using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace Nexa.Localization.Tests.Generators;

internal sealed class GeneratorTestResult
{
    public string GeneratedSource { get; }

    public ImmutableArray<Diagnostic> Diagnostics { get; }

    public GeneratorTestResult(
        string generatedSource,
        ImmutableArray<Diagnostic> diagnostics)
    {
        GeneratedSource = generatedSource;
        Diagnostics = diagnostics;
    }
}