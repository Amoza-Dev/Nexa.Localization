using FluentAssertions;
using Nexa.Localization.SourceGenerator.Models;
using Nexa.Localization.SourceGenerator.Parsing;

namespace Nexa.Localization.Tests.Parsing;

public sealed class JsonParserTests
{
    [Fact]
    public void Parse_Single_Key_Should_Return_One_Entry()
    {
        const string path = "buttons.json";

        const string json =
        """
        {
            "button.save": "Save"
        }
        """;

        var result = JsonParser.Parse(
            path,
            json);

        result.Path.Should().Be(path);

        result.Values.Should().HaveCount(1);

        result.Values.Should().ContainKey("button.save");

        result.Values["button.save"].Should().Be("Save");
    }

    [Fact]
    public void Parse_Multiple_Keys_Should_Return_All_Entries()
    {
        const string path = "buttons.json";

        const string json =
        """
        {
            "button.save": "Save",
            "button.cancel": "Cancel",
            "button.delete": "Delete"
        }
        """;

        var result = JsonParser.Parse(
            path,
            json);

        result.Values.Should().HaveCount(3);

        result.Values["button.save"].Should().Be("Save");
        result.Values["button.cancel"].Should().Be("Cancel");
        result.Values["button.delete"].Should().Be("Delete");
    }

    [Fact]
    public void Parse_Empty_Object_Should_Return_Empty_Dictionary()
    {
        const string path = "buttons.json";

        const string json = "{}";

        var result = JsonParser.Parse(
            path,
            json);

        result.Values.Should().BeEmpty();
    }

    [Fact]
    public void Parse_Null_Path_Should_Throw_ArgumentNullException()
    {
        const string json = "{}";

        Action action = () => JsonParser.Parse(
            null!,
            json);

        action.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("path");
    }

    [Fact]
    public void Parse_Null_Json_Should_Throw_ArgumentNullException()
    {
        Action action = () => JsonParser.Parse(
            "buttons.json",
            null!);

        action.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("json");
    }

    [Fact]
    public void Parse_Invalid_Json_Should_Throw_JsonException()
    {
        const string json =
        """
        {
            "button.save":
        """;

        Action action = () => JsonParser.Parse(
            "buttons.json",
            json);

        action.Should().Throw<System.Text.Json.JsonException>();
    }

    [Fact]
    public void Parse_Array_Should_Throw_InvalidOperationException()
    {
        const string json =
        """
        [
            {
                "button.save": "Save"
            }
        ]
        """;

        Action action = () => JsonParser.Parse(
            "buttons.json",
            json);

        action.Should()
            .Throw<System.Text.Json.JsonException>();
    }

    [Fact]
    public void Parse_Empty_String_Value_Should_Be_Allowed()
    {
        const string json =
        """
        {
            "button.save": ""
        }
        """;

        var result = JsonParser.Parse(
            "buttons.json",
            json);

        result.Values.Should().ContainKey("button.save");

        result.Values["button.save"].Should().BeEmpty();
    }

    [Fact]
    public void Parse_Should_Ignore_Non_String_Values()
    {
        const string json =
        """
        {
            "button.save":"Save",
            "version":1,
            "enabled":true
        }
        """;

        var result = JsonParser.Parse(
            "buttons.json",
            json);

        result.Values.Should().HaveCount(1);

        result.Values["button.save"].Should().Be("Save");
    }

    [Fact]
    public void Parse_Should_Create_Case_Insensitive_Dictionary()
    {
        const string json =
        """
        {
            "Button.Save":"Save"
        }
        """;

        var result = JsonParser.Parse(
            "buttons.json",
            json);

        result.Values.ContainsKey("button.save").Should().BeTrue();

        result.Values.ContainsKey("BUTTON.SAVE").Should().BeTrue();
    }
}