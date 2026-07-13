using Microsoft.CodeAnalysis;
using Nexa.Localization.SourceGenerator.Models;
using System.Collections.Generic;

namespace Nexa.Localization.SourceGenerator.Validation;

internal static class LocalizationValidator
{
    public static void Validate(
        SourceProductionContext context,
        IReadOnlyList<JsonFile> files)
    {
        InvalidKeyValidator.Validate(context, files);

        EmptyValueValidator.Validate(context, files);

        MissingKeyValidator.Validate(context, files);

        DuplicateKeyValidator.Validate(context, files);
    }
}