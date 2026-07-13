using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexa.Localization.SourceGenerator.Diagnostics
{
    internal static class InvalidJsonDiagnostic
    {
        public static readonly DiagnosticDescriptor Descriptor = new(
            id: "NEXALOC002",
            title: "Invalid JSON",
            messageFormat: "{0}",
            category: "Nexa.Localization",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public static void Report(
            SourceProductionContext context,
            Location location,
            string message)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(Descriptor, location, message));
        }
    }
}
