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

            (-1 <  money).Should().BeTrue();
            (43 >  money).Should().BeTrue();
            (41 <  money).Should().BeTrue();
            (43 >= money).Should().BeTrue();
            (41 <= money).Should().BeTrue();
            (42 <= money).Should().BeTrue();
            (42 >= money).Should().BeTrue();

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
            
            (43m >  money).Should().BeTrue();
            (41m <  money).Should().BeTrue();
            (43m >= money).Should().BeTrue();
            (41m <= money).Should().BeTrue();
            (42m <= money).Should().BeTrue();
            (42m >= money).Should().BeTrue();

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
        public void CompareTo__Money_Value_Passed__Return_Correct_Result()
        {
            var money = new UMoney(42, 0);
            
            (money <  Money.Create(43m)).Should().BeTrue();
            (money >  Money.Create(41m)).Should().BeTrue();
            (money <= Money.Create(43m)).Should().BeTrue();
            (money >= Money.Create(41m)).Should().BeTrue();
            (money <= Money.Create(42m)).Should().BeTrue();
            (money >= Money.Create(42m)).Should().BeTrue();
            
            (Money.Create(41m) <  money).Should().BeTrue();
            (Money.Create(43m) >  money).Should().BeTrue();
            (Money.Create(41m) <= money).Should().BeTrue();
            (Money.Create(43m) >= money).Should().BeTrue();
            (Money.Create(42m) <= money).Should().BeTrue();
            (Money.Create(42m) >= money).Should().BeTrue();
            
            money
                .CompareTo(Money.Create(41m))
                .Should()
                .BePositive();
            
            money
                .CompareTo(Money.Create(42m))
                .Should()
                .Be(0);
            
            money
                .CompareTo(Money.Create(43m))
                .Should()
                .BeNegative();
        }
        
        [TestMethod]
        public void Equals__Integer_Value_Passed__Return_Correct_Result()
        {
            var money = new UMoney(42, 0);
            
            (money == 42).Should().BeTrue();
            (money != 41).Should().BeTrue();
            
            (42 == money).Should().BeTrue();
            (41 != money).Should().BeTrue();

            money
                .Equals(42)
                .Should()
                .BeTrue();
            
            money
                .Equals(41)
                .Should()
                .BeFalse();
        }
        
        [TestMethod]
        public void Equals__Decimal_Value_Passed__Return_Correct_Result()
        {
            var money = new UMoney(42, 0);
            
            (money == 42m).Should().BeTrue();
            (money != 41m).Should().BeTrue();

            (42m == money).Should().BeTrue();
            (41m != money).Should().BeTrue();
            
            money
                .Equals(42m)
                .Should()
                .BeTrue();
            
            money
                .Equals(41m)
                .Should()
                .BeFalse();
        }
        
        [TestMethod]
        public void Equals__Money_Value_Passed__Return_Correct_Result()
        {
            var money = new UMoney(42, 0);
            
            (money == Money.Create(42m)).Should().BeTrue();
            (money != Money.Create(41m)).Should().BeTrue();

            (Money.Create(42m) == money).Should().BeTrue();
            (Money.Create(41m) != money).Should().BeTrue();
            
            money
                .Equals(Money.Create(42m))
                .Should()
                .BeTrue();
            
            money
                .Equals(Money.Create(41m))
                .Should()
                .BeFalse();
        }
    }
}