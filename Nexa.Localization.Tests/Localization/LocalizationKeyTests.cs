using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Nexa.Localization.Tests.Localization
{
    public class LocalizationKeyTests
    {
        [Fact]
        public void True_Should_Be_True()
        {
            true.Should().BeTrue();
        }
    }
}
