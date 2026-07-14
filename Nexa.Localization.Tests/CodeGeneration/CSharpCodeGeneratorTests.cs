using FluentAssertions;
using Nexa.Localization.SourceGenerator.CodeGeneration;
using Nexa.Localization.SourceGenerator.Models;

namespace Nexa.Localization.SourceGenerator.Tests.CodeGeneration;

public sealed class CSharpCodeGeneratorTests
{
    [Fact]
    public void Generate_Empty_Tree_Should_Create_Empty_Nexa_Class()
    {
        // Arrange
        var tree = new LocalizationTree();
        var generator = new CSharpCodeGenerator();

        // Act
        var source = generator.Generate(tree);

        // Assert
        source.Should().Contain("public static class Nexa");
        source.Should().Contain("namespace Nexa.Localization.Generated;");
    }

    [Fact]
    public void Generate_Single_Key_Should_Create_Const_String()
    {
        // Arrange
        var tree = new LocalizationTree();

        var button = new LocalizationNode("button", tree.Root);
        tree.Root.Children.Add("button", button);

        var save = new LocalizationNode("save", button)
        {
            IsLeaf = true
        };

        button.Children.Add("save", save);

        var generator = new CSharpCodeGenerator();

        // Act
        var source = generator.Generate(tree);

        // Assert
        source.Should().Contain("public static class Button");
        source.Should().Contain("public const string Save = \"button.save\";");
    }

    [Fact]
    public void Generate_Multiple_Keys_Should_Create_Multiple_Constants()
    {
        // Arrange
        var tree = new LocalizationTree();

        var button = new LocalizationNode("button", tree.Root);
        tree.Root.Children.Add("button", button);

        var save = new LocalizationNode("save", button)
        {
            IsLeaf = true
        };

        var cancel = new LocalizationNode("cancel", button)
        {
            IsLeaf = true
        };

        button.Children.Add("save", save);
        button.Children.Add("cancel", cancel);

        var generator = new CSharpCodeGenerator();

        // Act
        var source = generator.Generate(tree);

        // Assert
        source.Should().Contain("public const string Save");
        source.Should().Contain("public const string Cancel");
    }

    [Fact]
    public void Generate_Nested_Key_Should_Create_Nested_Class()
    {
        // Arrange
        var tree = new LocalizationTree();

        var invoice = new LocalizationNode("invoice", tree.Root);
        tree.Root.Children.Add("invoice", invoice);

        var create = new LocalizationNode("create", invoice);
        invoice.Children.Add("create", create);

        var success = new LocalizationNode("success", create)
        {
            IsLeaf = true
        };

        create.Children.Add("success", success);

        var generator = new CSharpCodeGenerator();

        // Act
        var source = generator.Generate(tree);

        // Assert
        source.Should().Contain("public static class Invoice");
        source.Should().Contain("public static class Create");
        source.Should().Contain("public const string Success = \"invoice.create.success\";");
    }

    [Fact]
    public void Generate_Null_Tree_Should_Throw()
    {
        // Arrange
        var generator = new CSharpCodeGenerator();

        // Act
        Action action = () => generator.Generate(null!);

        // Assert
        action.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("tree");
    }
}