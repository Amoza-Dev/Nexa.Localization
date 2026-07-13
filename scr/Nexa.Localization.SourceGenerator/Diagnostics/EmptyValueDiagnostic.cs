using Microsoft.CodeAnalysis;

namespace Nexa.Localization.SourceGenerator.Diagnostics;

internal static class EmptyValueDiagnostic
{
    public static readonly DiagnosticDescriptor Descriptor = new(
        id: "NEXALOC004",
        title: "Empty localization value",
        messageFormat: "Localization key '{0}' has an empty value.",
        category: "Nexa.Localization",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static void Report(
        SourceProductionContext context,
        Location location,
        string key)
    {
        context.ReportDiagnostic(
            Diagnostic.Create(Descriptor, location, key));
    }
}