using System;
using System.Numerics;
using JetBrains.Annotations;
using MessagePack;
using MessagePack.Formatters;

namespace Lykke.Numerics.MessagePack
{
    [PublicAPI]
    public sealed class MoneyFormatter : IMessagePackFormatter<Money>
    {
        private readonly TupleFormatter<byte[], int> _innerFormatter;
        
        public MoneyFormatter()
        {
            _innerFormatter = new TupleFormatter<byte[], int>();
        }
        
        public int Serialize(
            ref byte[] bytes,
            int offset,
            Money value,
            IFormatterResolver formatterResolver)
        {
            return _innerFormatter.Serialize
            (
                ref bytes,
                offset,
                new Tuple<byte[], int>(value.Significand.ToByteArray(), value.Scale),
                formatterResolver
            );
        }

        public Money Deserialize(
            byte[] bytes,
            int offset,
            IFormatterResolver formatterResolver, 
            out int readSize)
        {
            var (significandBytes, scale) = _innerFormatter.Deserialize
            (
                bytes,
                offset,
                formatterResolver,
                out readSize
            );

            var significand = new BigInteger(significandBytes);

            return new Money(significand, scale);
        }
    }
}