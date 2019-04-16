using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace Lykke.Numerics.MessagePack.Tests.Utils
{
    public class TestFormatterResolver : IFormatterResolver
    {
        private readonly IDictionary<Type, IMessagePackFormatter> _formatters;


        public TestFormatterResolver()
        {
            _formatters = new Dictionary<Type, IMessagePackFormatter>();
        }
            
        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            if (_formatters.TryGetValue(typeof(T), out var formatter))
            {
                return (IMessagePackFormatter<T>) formatter;
            }
            else
            {
                return StandardResolver.Instance.GetFormatter<T>();
            }
        }

        public TestFormatterResolver SetFormatter<T>(
            // ReSharper disable once SuggestBaseTypeForParameter
            IMessagePackFormatter<T> formatter)
        {
            _formatters[typeof(T)] = formatter;

            return this;
        }
    }
}