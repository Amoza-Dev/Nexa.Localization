using FluentAssertions;

namespace Nexa.Localization.Tests.Generators;

public class MissingKeyTests
{
    [Fact]
    public void Missing_Key_In_One_Culture_Should_Report_Diagnostic()
    {
        // Arrange
        var result = GeneratorTestHelper.Run(
            new InMemoryAdditionalText(
                "Localization/en/buttons.json",
                """
                {
                    "button.save": "Save",
                    "button.cancel": "Cancel"
                }
                """),
            new InMemoryAdditionalText(
                "Localization/ar/buttons.json",
                """
                {
                    "button.save": "حفظ"
                }
                """));

        // Assert
        result.Diagnostics.Should().ContainSingle();

        result.Diagnostics[0].Id.Should().Be("NEXALOC005");
    }
}