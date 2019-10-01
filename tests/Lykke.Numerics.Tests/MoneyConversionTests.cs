using FluentAssertions;
using Lykke.Numerics.Tests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Lykke.Numerics.Tests
{
    [TestClass]
    public class MoneyConversionTests
    {
        [DataTestMethod]
        [DataRow("42.05", 2, "4205")]
        [DataRow("42.35", 1, "424")]
        [DataRow("42.56", 3, "42560")]
        public void Denominate__Returns_Correct_Result(
            string value,
            int scale,
            string expectedResult)
        {
            var money = Money.Parse(value);

            Money
                .Denominate(money, scale)
                .Should()
                .Be(expectedResult);
        }
        
        [TestMethod]
        public void Money_Should_Be_Serializable_To_Json()
        {
            JsonConvert
                .SerializeObject(Money.Create(10, 5))
                .Should()
                .Be("\"10.00000\"");
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Serializable_To_Json()
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            Money? value;

            value = Money.Create(10, 5);
            
            JsonConvert
                .SerializeObject(value)
                .Should()
                .Be("\"10.00000\"");

            value = null;
            
            JsonConvert
                // ReSharper disable once ExpressionIsAlwaysNull
                .SerializeObject(value)
                .Should()
                .Be("null");
        }
        
        [TestMethod]
        public void Money_Should_Be_Deserializable_From_Json()
        {
            JsonConvert
                .DeserializeObject<Money>("\"10.00000\"")
                .Should()
                .Be(Money.Create(10, 5));
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Deserializable_From_Json()
        {
            JsonConvert
                .DeserializeObject<Money?>("\"10.00000\"")
                .Should()
                .Be(Money.Create(10, 5));
            
            JsonConvert
                .DeserializeObject<Money?>("null")
                .Should()
                .BeNull();
        }

        [DataTestMethod]
        [DataRow("42.05", "42.05")]
        [DataRow("42.00", "42")]
        public void Cast_To_Decimal__Produces_Correct_Result(
            string value,
            string expectedResult)
        {
            ((decimal) Money.Parse(value))
                .Should()
                .Be(decimal.Parse(expectedResult));
        }

        [DataTestMethod]
        public void Cast_To_Decimal_With_Overflowing_Significand_On_Trailing_Zeros__Produces_Correct_Result()
        {
            var decimalMaxValue = (Money)decimal.MaxValue;
            var overflowingInDecimal = new Money(decimalMaxValue.Significand * 10, 1);
            ((decimal)overflowingInDecimal)
                .Should()
                .Be(decimal.MaxValue);
        }

        [DataTestMethod]
        public void Cast_To_Decimal_With_Overflowing_Significand__Produces_Correct_Result()
        {
            var decimalMaxValue = (Money)decimal.MaxValue;
            var overflowingInDecimal = new Money(decimalMaxValue.Significand * 10 - 1, 1);
            ((decimal)overflowingInDecimal)
                .Should()
                .Be(decimal.MaxValue);
        }
    }
}