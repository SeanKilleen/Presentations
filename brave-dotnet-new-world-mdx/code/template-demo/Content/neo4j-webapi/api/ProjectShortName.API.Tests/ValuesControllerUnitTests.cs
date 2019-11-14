using System;
using FluentAssertions;
using ProjectShortName.API.Controllers;
using Xunit;

namespace ProjectShortName.API.Tests
{
    public class ValuesControllerUnitTests
    {
        [Fact]
        public void Ctor_WithNullDriver_ThrowsException()
        {
            // ReSharper disable once ObjectCreationAsStatement -- needed for tests
            Action act = () => new ValuesController(null);

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("neo4jClient");
        }
    }
}
