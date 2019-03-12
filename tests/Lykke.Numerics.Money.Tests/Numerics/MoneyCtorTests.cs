using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics
{
    [TestClass]
    public class MoneyCtorTests
    {
        [DataTestMethod]
        [DataRow("0")]
        [DataRow("0.0")]
        [DataRow("0.01")]
        [DataRow("0.010")]
        [DataRow("42")]
        [DataRow("42.0")]
        [DataRow("42.01")]
        [DataRow("42.010")]
        [DataRow("-1")]
        public void Decimal_Value_Passed__Correct_BigDecimal_Created(string a)
        {
            var d = decimal.Parse(a);
            
            Money
                .Create(d)
                .Should()
                .Be(a);
        }
        
        [TestMethod]
        public void Negative_Scale_Passed__ArgumentException_Thrown()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action createBigDecimal = () => { new Money(42, -1); };

            createBigDecimal
                .Should()
                .Throw<ArgumentException>();
        }

        [DataTestMethod]
        [DataRow("-42.42")]
        [DataRow("-42.0")]
        [DataRow("-42")]
        [DataRow("-0.42")]
        [DataRow("0")]
        [DataRow("0.0")]
        [DataRow("0.42")]
        [DataRow("42")]
        [DataRow("42.0")]
        [DataRow("42.42")]
        [DataRow("+1")]
        public void Parse__Value_Correctly_Parsed(string a)
        {
            Money
                .Parse(a)
                .Should()
                .Be(a);
        }

        [DataTestMethod]
        [DataRow("(1)")]
        [DataRow(" 1")]
        [DataRow("1 ")]
        [DataRow("1,2")]
        [DataRow("1_2")]
        [DataRow("1 2")]
        [DataRow(".12")]
        [DataRow("0.12m")]
        public void Parse__Invalid_String_Passed__FormatException_Thrown(string a)
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action parse = () => Money.Parse(a);

            parse
                .Should()
                .ThrowExactly<FormatException>();
        }
    }
}