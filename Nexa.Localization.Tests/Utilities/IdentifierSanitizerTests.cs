using FluentAssertions;
using Nexa.Localization.SourceGenerator.Utilities;

namespace Nexa.Localization.Tests.Utilities;

public sealed class IdentifierSanitizerTests
{
    [Fact]
    public void Sanitize_Simple_Name_Should_Return_PascalCase()
    {
        // Arrange
        const string value = "button";

        // Act
        var result = IdentifierSanitizer.Sanitize(value);

        // Assert
        result.Should().Be("Button");
    }
    [Fact]
    public void Sanitize_Dash_Should_Remove_Dash()
    {
        // Arrange
        const string value = "button-save";

        // Act
        var result = IdentifierSanitizer.Sanitize(value);

        // Assert
        result.Should().Be("ButtonSave");
    }
    [Fact]
    public void Sanitize_Underscore_Should_Remove_Underscore()
    {
        const string value = "button_save";

        var result = IdentifierSanitizer.Sanitize(value);

        result.Should().Be("ButtonSave");
    }
    [Fact]
    public void Sanitize_Space_Should_Remove_Space()
    {
        const string value = "button save";

        var result = IdentifierSanitizer.Sanitize(value);

        result.Should().Be("ButtonSave");
    }
    [Fact]
    public void Sanitize_Starting_With_Digit_Should_Prefix_Underscore()
    {
        const string value = "123button";

        var result = IdentifierSanitizer.Sanitize(value);

        result.Should().Be("_123button");
    }
    [Fact]
    public void Sanitize_Empty_Should_Return_Underscore()
    {
        var result = IdentifierSanitizer.Sanitize("");

        result.Should().Be("_");
    }
    [Fact]
    public void Sanitize_Null_Should_Return_Underscore()
    {
        var result = IdentifierSanitizer.Sanitize(null!);

        result.Should().Be("_");
    }
    [Fact]
    public void Sanitize_Only_Symbols_Should_Return_Underscore()
    {
        var result = IdentifierSanitizer.Sanitize("----");

        result.Should().Be("_");
    }
}