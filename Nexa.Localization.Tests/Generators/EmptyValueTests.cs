using FluentAssertions;

namespace Nexa.Localization.Tests.Generators;

public class EmptyValueTests
{
    [Fact]
    public void Empty_Value_Should_Report_Diagnostic()
    {
        // Arrange
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
                {
                    "button.save": ""
                }
                """));

        // Assert
        result.Diagnostics.Should().ContainSingle();

        result.Diagnostics[0].Id.Should().Be("NEXALOC004");
    }
}