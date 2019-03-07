using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.Money.Tests
{
    [TestClass]
    public class UMoneyComparisonTests
    {
        [TestMethod]
        public void CompareTo__Integer_Value_Passed__Returns_Correct_Result()
        {
            var money = new UMoney(42, 0);


            (money >  -1).Should().BeTrue();
            (money <  43).Should().BeTrue();
            (money >  41).Should().BeTrue();
            (money <= 43).Should().BeTrue();
            (money >= 41).Should().BeTrue();
            (money <= 42).Should().BeTrue();
            (money >= 42).Should().BeTrue();
            (money == 42).Should().BeTrue();
            (money != 41).Should().BeTrue();

            (-1 <  money).Should().BeTrue();
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
            var money = new UMoney(42, 0);
            
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
    }
}