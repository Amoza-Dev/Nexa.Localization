using Microsoft.CodeAnalysis;

namespace Nexa.Localization.SourceGenerator.Diagnostics;

internal static class DiagnosticDescriptors
{
    public static DiagnosticDescriptor DuplicateKey
        => DuplicateKeyDiagnostic.Descriptor;

    public static DiagnosticDescriptor InvalidJson
        => InvalidJsonDiagnostic.Descriptor;
}