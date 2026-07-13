using Microsoft.CodeAnalysis;

namespace Nexa.Localization.SourceGenerator.Diagnostics;

internal static class InvalidKeyDiagnostic
{
    public static readonly DiagnosticDescriptor Descriptor = new(
        id: "NEXALOC003",
        title: "Invalid localization key",
        messageFormat: "Localization key '{0}' is invalid.",
        category: "Nexa.Localization",
        defaultSeverity: DiagnosticSeverity.Error,
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