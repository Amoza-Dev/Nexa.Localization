using Microsoft.CodeAnalysis;

namespace Nexa.Localization.SourceGenerator.Diagnostics;

internal static class MissingKeyDiagnostic
{
    public static readonly DiagnosticDescriptor Descriptor = new(
        id: "NEXALOC005",
        title: "Missing localization key",
        messageFormat: "Localization key '{0}' is missing in one or more cultures.",
        category: "Nexa.Localization",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static void Report(
        SourceProductionContext context,
        Location location,
        string key)
    {
        context.ReportDiagnostic(
            Diagnostic.Create(
                Descriptor,
                location,
                key));
    }
}