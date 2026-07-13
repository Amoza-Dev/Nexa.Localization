using Microsoft.CodeAnalysis;
using Nexa.Localization.SourceGenerator.Diagnostics;
using Nexa.Localization.SourceGenerator.Models;
using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class InvalidKeyValidator
{
    public static void Validate(
        SourceProductionContext context,
        IReadOnlyList<JsonFile> files)
    {
        foreach (var file in files)
        {
            foreach (var key in file.Values.Keys)
            {
                if (!LocalizationKeyValidator.IsValid(key))
                {
                    InvalidKeyDiagnostic.Report(
                        context,
                        Location.None,
                        key);
                }
            }
        }
    }
}