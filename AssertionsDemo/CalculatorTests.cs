using System;
using FluentAssertions;
using NUnit.Framework;

namespace AssertionsDemo
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Can_Add_Integer()
        {
            int total = Calculator.Add(1, 2);
            Assert.AreEqual(3, total);
        }

        [Test]
        public void Can_Add_Integer_Using_Constraints()
        {
            int total = Calculator.Add(1, 2);
            Assert.That(total, Is.EqualTo(3));
        }

        [Test]
        public void Can_Add_Integer_Using_FluentAssertions()
        {
            int total = Calculator.Add(1, 2);
            total.Should().Be(3);
        }

        [Test]
        public void Cannot_Subtract_And_Throw_NotSupportedException()
        {
            Action action = () => Calculator.Subtract(5, 3);
            action.ShouldThrow<NotSupportedException>().WithMessage("Not yet implemented");
        }
    }
}