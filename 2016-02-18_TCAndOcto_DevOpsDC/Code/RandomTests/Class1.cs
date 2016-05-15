using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RandomTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void MathStillWorks()
        {
            var result = 1 + 1;

            result.Should().Be(2);
        }
    }
}
