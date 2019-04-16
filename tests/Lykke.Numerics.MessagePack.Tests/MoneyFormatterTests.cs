using FluentAssertions;
using Lykke.Numerics.MessagePack.Tests.Utils;
using MessagePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.MessagePack.Tests
{
    [TestClass]
    public class MoneyFormatterTests
    {
        private readonly Money _expectedDeserializedValue;
        private readonly byte[] _expectedSerializedValue;
        private readonly TestFormatterResolver _formatterResolver;

        public MoneyFormatterTests()
        {
            _expectedDeserializedValue = Money.Parse("42.0");
            _expectedSerializedValue = new byte[] { 146, 196, 2, 164, 1, 1 };
            _formatterResolver = new TestFormatterResolver();

            _formatterResolver
                .SetFormatter(new MoneyFormatter());
        }
        
        [TestMethod]
        public void Deserialize__Correctly_Serializes_Money_Value()
        {
            MessagePackSerializer
                .Deserialize<Money>(_expectedSerializedValue, _formatterResolver)
                .Should()
                .Be(_expectedDeserializedValue);
        }
        
        [TestMethod]
        public void Serialize__Correctly_Serializes_Money_Value()
        {
            MessagePackSerializer
                .Serialize(_expectedDeserializedValue, _formatterResolver)
                .Should()
                .Equal(_expectedSerializedValue);
        }
    }
}