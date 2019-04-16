using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lykke.Numerics.MessagePack.Tests
{
    [TestClass]
    public class MoneyResolverTests
    {   
        [TestMethod]
        public void GetFormatter__Money_Type_Specified__Returns_MoneyFormatter()
        {
            MoneyResolver.Instance
                .GetFormatter<Money>()
                .Should()
                .BeOfType<MoneyFormatter>();
        }
        
        [TestMethod]
        public void GetFormatter__UMoney_Type_Specified__Returns_UMoneyFormatter()
        {
            MoneyResolver.Instance
                .GetFormatter<UMoney>()
                .Should()
                .BeOfType<UMoneyFormatter>();
        }
        
        [TestMethod]
        public void GetFormatter__Neither_Money_Nor_UMoney_Type_Specified__Returns_Null()
        {
            MoneyResolver.Instance
                .GetFormatter<string>()
                .Should()
                .BeNull();
        }
    }
}