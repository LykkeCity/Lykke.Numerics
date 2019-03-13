using System;
using System.Collections.Generic;
using System.Linq;
using Lykke.Numerics.Utils;

namespace Lykke.Numerics.Linq
{
    public static partial class Enumerable
    {
        public static Money Max(
            this IEnumerable<Money> source)
        {
            if (source == null)
            {
                throw ThrowHelper.SourceArgumentNullException();
            }

            Money result;
            
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw ThrowHelper.SequenceContainsNoElementsException();
                }

                result = enumerator.Current;
                
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    
                    if (current > result)
                    {
                        result = current;
                    }
                }
            }

            return result;
        }
        
        public static Money? Max(
            this IEnumerable<Money?> source)
        {
            if (source == null)
            {
                throw ThrowHelper.SourceArgumentNullException();
            }

            Money? result = null;
            
            using (var enumerator = source.GetEnumerator())
            {
                do
                {
                    if (!enumerator.MoveNext())
                    {
                        return result;
                    }

                    result = enumerator.Current;
                }
                while (!result.HasValue);

                var resultValue = result.GetValueOrDefault();
                
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    var currentValue = current.GetValueOrDefault();
                    
                    if (current.HasValue && currentValue > resultValue)
                    {
                        resultValue = currentValue;
                        result = current;
                    }
                }
            }

            return result;
        }
        
        public static Money Max<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Money> selector)
        {
            return source
                .Select(selector)
                .Max();
        }

        public static Money? Max<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Money?> selector)
        {
            return source
                .Select(selector)
                .Max();
        }
    }
}