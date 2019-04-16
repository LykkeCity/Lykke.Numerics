using System;
using System.Numerics;
using JetBrains.Annotations;
using MessagePack;
using MessagePack.Formatters;

namespace Lykke.Numerics.MessagePack
{
    [PublicAPI]
    public sealed class UMoneyFormatter : IMessagePackFormatter<UMoney>
    {   
        private readonly TupleFormatter<byte[], int> _innerFormatter;
        
        public UMoneyFormatter()
        {
            _innerFormatter = new TupleFormatter<byte[], int>();
        }
        
        public int Serialize(
            ref byte[] bytes,
            int offset,
            UMoney value,
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

        public UMoney Deserialize(
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

            return new UMoney(significand, scale);
        }
    }
}