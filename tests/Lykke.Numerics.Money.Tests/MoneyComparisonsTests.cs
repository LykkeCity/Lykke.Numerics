using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.Money.Tests
{
    [TestClass]
    public class MoneyComparisonsTests
    {
        [TestMethod]
        public void CompareTo__Integer_Value_Passed__Returns_Correct_Result()
        {
            var money = new Money(42, 0);
            
            (money <  43).Should().BeTrue();
            (money >  41).Should().BeTrue();
            (money <= 43).Should().BeTrue();
            (money >= 41).Should().BeTrue();
            (money <= 42).Should().BeTrue();
            (money >= 42).Should().BeTrue();
            (money == 42).Should().BeTrue();
            (money != 41).Should().BeTrue();
            
            (43 >  money).Should().BeTrue();
            (41 <  money).Should().BeTrue();
            (43 >= money).Should().BeTrue();
            (41 <= money).Should().BeTrue();
            (42 <= money).Should().BeTrue();
            (42 >= money).Should().BeTrue();
            (42 == money).Should().BeTrue();
            (41 != money).Should().BeTrue();

            money
                .CompareTo(41)
                .Should()
                .BePositive();
            
            money
                .CompareTo(42)
                .Should()
                .Be(0);
            
            money
                .CompareTo(43)
                .Should()
                .BeNegative();
        }
        
        [TestMethod]
        public void CompareTo__Decimal_Value_Passed__Returns_Correct_Result()
        {
            var money = new Money(42, 0);
            
            (money <  43m).Should().BeTrue();
            (money >  41m).Should().BeTrue();
            (money <= 43m).Should().BeTrue();
            (money >= 41m).Should().BeTrue();
            (money <= 42m).Should().BeTrue();
            (money >= 42m).Should().BeTrue();
            (money == 42m).Should().BeTrue();
            (money != 41m).Should().BeTrue();
            
            (43m >  money).Should().BeTrue();
            (41m <  money).Should().BeTrue();
            (43m >= money).Should().BeTrue();
            (41m <= money).Should().BeTrue();
            (42m <= money).Should().BeTrue();
            (42m >= money).Should().BeTrue();
            (42m == money).Should().BeTrue();
            (41m != money).Should().BeTrue();

            money
                .CompareTo(41m)
                .Should()
                .BePositive();
            
            money
                .CompareTo(42m)
                .Should()
                .Be(0);
            
            money
                .CompareTo(43m)
                .Should()
                .BeNegative();
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