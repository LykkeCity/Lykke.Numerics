using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Lykke.Numerics
{
    [TestClass]
    public class MoneyConversionTests
    {
        [TestMethod]
        public void Money_Should_Be_Serializable_To_Json_Without_Json_Converter()
        {
            JsonConvert
                .SerializeObject(Money.Create(10, 5))
                .Should()
                .Be("\"10.00000\"");
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Serializable_To_Json_Without_Json_Converter()
        {
            JsonConvert
                .SerializeObject((Money?) Money.Create(10, 5))
                .Should()
                .Be("\"10.00000\"");
            
            JsonConvert
                .SerializeObject((Money?) null)
                .Should()
                .Be("null");
        }
        
        [TestMethod]
        public void Money_Should_Be_Deserializable_From_Json_Without_Json_Converter()
        {
            JsonConvert
                .DeserializeObject<Money>("\"10.00000\"")
                .Should()
                .Be(Money.Create(10, 5));
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Deserializable_From_Json_Without_Json_Converter()
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