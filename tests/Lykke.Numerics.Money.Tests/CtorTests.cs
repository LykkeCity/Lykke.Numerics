using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.Money.Tests
{
    [TestClass]
    public class CtorTests
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
        public void Parse__Value_Correctly_Parsed(string a)
        {
            Money
                .Parse(a)
                .Should()
                .Be(a);
        }
    }
}