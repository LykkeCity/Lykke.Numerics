using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.Money.Tests
{
    [TestClass]
    public class EqualityTests
    {
        [TestMethod]
        public void Equals__Should_Return_True_For_Equal_Values()
        {
            var left = new Money(42, 1);
            var right = new Money(42, 1);

            left.Equals(right)
                .Should()
                .BeTrue();
        }
        
        [TestMethod]
        public void Equals__Should_Ignore_Trailing_Zeroes()
        {
            var left = new Money(42, 1);
            var right = new Money(420, 2);

            left.Equals(right)
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void GetHashCode__Should_Be_Same_For_Equal_Values()
        {
            var left = (new Money(42, 1))
                .GetHashCode();
            
            var right = (new Money(42, 1))
                .GetHashCode();

            left
                .Should()
                .Be(right);
        }
        
        [TestMethod]
        public void GetHashCode__Should_Ignore_Trailing_Zeroes()
        {
            var left = (new Money(42, 1))
                .GetHashCode();
            
            var right = (new Money(420, 2))
                .GetHashCode();

            left
                .Should()
                .Be(right);
        }
    }
    
    
}

