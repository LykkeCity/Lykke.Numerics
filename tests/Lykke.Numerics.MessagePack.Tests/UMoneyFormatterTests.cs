using FluentAssertions;
using Lykke.Numerics.MessagePack.Tests.Utils;
using MessagePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.MessagePack.Tests
{
    [TestClass]
    public class UMoneyFormatterTests
    {
        private readonly UMoney _expectedDeserializedValue;
        private readonly byte[] _expectedSerializedValue;
        private readonly TestFormatterResolver _formatterResolver;

        public UMoneyFormatterTests()
        {
            _expectedDeserializedValue = UMoney.Parse("42.0");
            _expectedSerializedValue = new byte[] { 146, 196, 2, 164, 1, 1 };
            _formatterResolver = new TestFormatterResolver();

            _formatterResolver
                .SetFormatter(new UMoneyFormatter());
        }
        
        [TestMethod]
        public void Deserialize__Correctly_Serializes_Money_Value()
        {
            MessagePackSerializer
                .Deserialize<UMoney>(_expectedSerializedValue, _formatterResolver)
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