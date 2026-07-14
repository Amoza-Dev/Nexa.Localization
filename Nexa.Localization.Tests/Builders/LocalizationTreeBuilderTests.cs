using FluentAssertions;
using Nexa.Localization.SourceGenerator.Builders;
using Nexa.Localization.SourceGenerator.Models;

namespace Nexa.Localization.SourceGenerator.Tests.Builders;

public sealed class LocalizationTreeBuilderTests
{
    [Fact]
    public void Build_Single_Key_Should_Create_Tree()
    {
        // Arrange
        var file = new JsonFile(
            "Localization/en/buttons.json",
            "en",
            new Dictionary<string, string>
            {
                ["button.save"] = "Save"
            });

        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([file]);

        // Assert
        tree.Root.Children.Should().ContainKey("button");

        var button = tree.Root.Children["button"];

        button.Children.Should().ContainKey("save");

        button.IsLeaf.Should().BeFalse();

        button.Children["save"].IsLeaf.Should().BeTrue();
    }

    [Fact]
    public void Build_Multiple_Keys_Should_Share_Common_Node()
    {
        // Arrange
        var file = new JsonFile(
            "Localization/en/buttons.json",
            "en",
            new Dictionary<string, string>
            {
                ["button.save"] = "Save",
                ["button.cancel"] = "Cancel"
            });

        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([file]);

        // Assert
        tree.Root.Children.Should().HaveCount(1);

        var button = tree.Root.Children["button"];

        button.Children.Should().HaveCount(2);

        button.Children.Should().ContainKey("save");

        button.Children.Should().ContainKey("cancel");
    }

    [Fact]
    public void Build_Should_Set_Parent_For_All_Nodes()
    {
        // Arrange
        var file = new JsonFile(
            "Localization/en/buttons.json",
            "en",
            new Dictionary<string, string>
            {
                ["button.save"] = "Save"
            });

        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([file]);

        // Assert
        var button = tree.Root.Children["button"];

        var save = button.Children["save"];

        button.Parent.Should().Be(tree.Root);

        save.Parent.Should().Be(button);
    }

    [Fact]
    public void Build_Should_Set_FullKey()
    {
        // Arrange
        var file = new JsonFile(
            "Localization/en/buttons.json",
            "en",
            new Dictionary<string, string>
            {
                ["button.save"] = "Save"
            });

        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([file]);

        // Assert
        var save = tree.Root.Children["button"].Children["save"];

        save.FullKey.Should().Be("button.save");
    }

    [Fact]
    public void Build_Empty_Input_Should_Return_Empty_Tree()
    {
        // Arrange
        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([]);

        // Assert
        tree.Root.Children.Should().BeEmpty();
    }

    [Fact]
    public void Build_Multiple_Files_Should_Merge_Keys()
    {
        // Arrange
        var file1 = new JsonFile(
            "Localization/en/buttons.json",
            "en",
            new Dictionary<string, string>
            {
                ["button.save"] = "Save"
            });

        var file2 = new JsonFile(
            "Localization/en/messages.json",
            "en",
            new Dictionary<string, string>
            {
                ["message.success"] = "Success"
            });

        var builder = new LocalizationTreeBuilder();

        // Act
        var tree = builder.Build([file1, file2]);

        // Assert
        tree.Root.Children.Should().ContainKey("button");
        tree.Root.Children.Should().ContainKey("message");
    }
}