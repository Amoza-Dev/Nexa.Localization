using System.Text;

namespace Nexa.Localization.SourceGenerator.CodeGeneration;

internal sealed class SourceCodeBuilder
{
    private readonly StringBuilder _builder = new();

    public void Append(string text)
    {
        _builder.Append(text);
    }

    public void AppendLine()
    {
        _builder.AppendLine();
    }

    public void AppendLine(string text)
    {
        _builder.AppendLine(text);
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}