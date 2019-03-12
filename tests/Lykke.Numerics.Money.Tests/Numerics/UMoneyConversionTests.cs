using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Lykke.Numerics
{
    [TestClass]
    public class UMoneyConversionTests
    {
        [TestMethod]
        public void Money_Should_Be_Serializable_To_Json()
        {
            JsonConvert
                .SerializeObject(UMoney.Create(10, 5))
                .Should()
                .Be("\"10.00000\"");
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Serializable_To_Json()
        {
            JsonConvert
                .SerializeObject((UMoney?) UMoney.Create(10, 5))
                .Should()
                .Be("\"10.00000\"");
            
            JsonConvert
                .SerializeObject((Money?) null)
                .Should()
                .Be("null");
        }
        
        [TestMethod]
        public void Money_Should_Be_Deserializable_From_Json()
        {
            JsonConvert
                .DeserializeObject<UMoney>("\"10.00000\"")
                .Should()
                .Be(UMoney.Create(10, 5));
        }
        
        [TestMethod]
        public void Nullable_Money_Should_Be_Deserializable_From_Json()
        {
            JsonConvert
                .DeserializeObject<UMoney?>("\"10.00000\"")
                .Should()
                .Be(UMoney.Create(10, 5));
            
            JsonConvert
                .DeserializeObject<UMoney?>("null")
                .Should()
                .BeNull();
        }
    }
}