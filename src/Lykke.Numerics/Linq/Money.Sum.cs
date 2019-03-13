using System;
using System.Collections.Generic;
using System.Linq;

using static Lykke.Numerics.Utils.ThrowHelper;

namespace Lykke.Numerics.Linq
{
    public static partial class LykkeEnumerable
    {
        public static Money Sum(
            this IEnumerable<Money> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            var sum = (Money) 0;

            return source
                .Aggregate(sum, (a, b) => a + b);
        }

        public static Money? Sum(
            this IEnumerable<Money?> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            var sum = (Money) 0;
            
            return source
                .Where(x => x.HasValue)
                .Aggregate(sum, (a, b) => a + b.Value);
        }
        
        public static Money Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Money> selector)
        {
            return source
                .Select(selector)
                .Sum();
        }

        public static Money? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Money?> selector)
        {
            return source
                .Select(selector)
                .Sum();
        }
    }
}