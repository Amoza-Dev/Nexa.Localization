using FluentAssertions;

namespace Nexa.Localization.Tests.Generators;

public class DuplicateKeyTests
{
    [Fact]
    public void Duplicate_Key_In_Same_Culture_Should_Report_Diagnostic()
    {
        // Arrange
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
                {
                    "button.add": "Add"
                }
                """),
            new InMemoryAdditionalText(
                "Localization/en/common.json",
                """
                {
                    "button.add": "Create"
                }
                """));

        // Assert
        result.Diagnostics.Should().ContainSingle();

        result.Diagnostics[0].Id.Should().Be("NEXALOC001");
    }

    [Fact]
    public void Different_Full_Keys_Should_Not_Report_Duplicate()
    {
        // Arrange
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
                {
                    "button.add": "Add"
                }
                """),
            new InMemoryAdditionalText(
                "Localization/en/payment.json",
                """
                {
                    "payment.add": "Add Payment"
                }
                """));

        // Assert
        result.Diagnostics
            .Should()
            .NotContain(d => d.Id == "NEXALOC001");
    }
    [Fact]
    public void Same_Key_In_Different_Cultures_Should_Not_Report_Diagnostic()
    {
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
            {
                "button.add": "Add"
            }
            """),
            new InMemoryAdditionalText(
                "Localization/ar/buttons.json",
                """
            {
                "button.add": "إضافة"
            }
            """));

        result.Diagnostics
            .Should()
            .NotContain(d => d.Id == "NEXALOC001");
    }
}