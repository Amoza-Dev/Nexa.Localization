using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Nexa.Localization.Tests.Generators;

internal sealed class InMemoryAdditionalText : AdditionalText
{
    private readonly SourceText _text;

    public override string Path { get; }

    public InMemoryAdditionalText(
        string path,
        string content)
    {
        Path = path;
        _text = SourceText.From(content, Encoding.UTF8);
    }

    public override SourceText GetText(
        CancellationToken cancellationToken = default)
    {
        return _text;
    }
}