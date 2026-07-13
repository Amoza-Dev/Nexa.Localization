using Microsoft.CodeAnalysis;

namespace Nexa.Localization.SourceGenerator.Diagnostics;

internal static class DuplicateKeyDiagnostic
{
    public static readonly DiagnosticDescriptor Descriptor = new(
        id: "NEXALOC001",
        title: "Duplicate localization key",
        messageFormat:
            "Localization key '{0}' is duplicated in '{1}' and '{2}'.",
        category: "Nexa.Localization",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static void Report(
        SourceProductionContext context,
        Location location,
        string key,
        string firstFile,
        string secondFile)
    {
        context.ReportDiagnostic(
            Diagnostic.Create(
                Descriptor,
                location,
                key,
                firstFile,
                secondFile));
    }
}