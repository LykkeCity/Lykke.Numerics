using System;
using JetBrains.Annotations;
using MessagePack;
using MessagePack.Formatters;

namespace Lykke.Numerics.MessagePack
{
    [PublicAPI]
    public sealed class MoneyResolver : IFormatterResolver
    {
        public static IFormatterResolver Instance { get; }
            = new MoneyResolver();
        
        
        private readonly IMessagePackFormatter _moneyFormatter;
        private readonly Type _moneyType;
        private readonly IMessagePackFormatter _uMoneyFormatter;
        private readonly Type _uMoneyType;


        private MoneyResolver()
        {
            _moneyFormatter = new MoneyFormatter();
            _moneyType = typeof(Money);
            _uMoneyFormatter = new UMoneyFormatter();
            _uMoneyType = typeof(UMoney);
        }
        
        
        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            IMessagePackFormatter formatter;
            
            if (typeof(T) == _moneyType)
            {
                formatter = _moneyFormatter;
            }
            else if (typeof(T) == _uMoneyType)
            {
                formatter = _uMoneyFormatter;
            }
            else
            {
                formatter = null;
            }

            return (IMessagePackFormatter<T>) formatter;
        }
    }
}