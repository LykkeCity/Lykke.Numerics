using FluentAssertions;
using Lykke.Numerics.Tests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Lykke.Numerics.Tests
{
    [TestClass]
    public class MoneyConversionTests
    {
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
    }
}