using FluentAssertions;

namespace Nexa.Localization.Tests.Generators;

public class InvalidKeyTests
{
    [Fact]
    public void Invalid_Key_Should_Report_Diagnostic()
    {
        // Arrange
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
                {
                    "Button.Save": "Save"
                }
                """));

        // Assert
        result.Diagnostics.Should().ContainSingle();

        result.Diagnostics[0].Id.Should().Be("NEXALOC003");
    }
}