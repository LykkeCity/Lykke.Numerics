using System;
using System.Collections.Generic;
using System.Linq;

using static Lykke.Numerics.Utils.ThrowHelper;

namespace Lykke.Numerics.Linq
{
    public static partial class Enumerable
    {
        public static UMoney Min(
            this IEnumerable<UMoney> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            UMoney result;
            
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw SequenceContainsNoElementsException();
                }

                result = enumerator.Current;
                
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    
                    if (current < result)
                    {
                        result = current;
                    }
                }
            }

            return result;
        }

        public static UMoney? Min(
            this IEnumerable<UMoney?> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            UMoney? result = null;
            
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
                    
                    if (current.HasValue && currentValue < resultValue)
                    {
                        resultValue = currentValue;
                        result = current;
                    }
                }
            }

            return result;
        }
        
        public static UMoney Min<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, UMoney> selector)
        {
            return source
                .Select(selector)
                .Min();
        }

        public static UMoney? Min<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, UMoney?> selector)
        {
            return source
                .Select(selector)
                .Min();
        }
    }
}