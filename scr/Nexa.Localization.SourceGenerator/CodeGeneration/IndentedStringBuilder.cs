using System.Text;

namespace Nexa.Localization.SourceGenerator.CodeGeneration;

internal sealed class IndentedStringBuilder
{
    private readonly StringBuilder _builder = new();

    private int _indent;

    private const string IndentText = "    ";

    public void Indent()
    {
        _indent++;
    }

    public void Unindent()
    {
        if (_indent > 0)
            _indent--;
    }

    public void AppendLine()
    {
        _builder.AppendLine();
    }

    public void AppendLine(string text)
    {
        for (int i = 0; i < _indent; i++)
            _builder.Append(IndentText);

        _builder.AppendLine(text);
    }

    public void Append(string text)
    {
        _builder.Append(text);
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}