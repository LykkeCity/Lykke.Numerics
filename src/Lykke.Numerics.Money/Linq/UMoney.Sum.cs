using System;
using System.Collections.Generic;
using System.Linq;
using Lykke.Numerics;

using static Lykke.Linq.ThrowHelper;

namespace Lykke.Linq
{
    public static partial class UMoneyEnumerable
    {
        public static UMoney Sum(
            this IEnumerable<UMoney> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            var sum = (UMoney) 0;

            return source
                .Aggregate(sum, (a, b) => a + b);
        }

        public static UMoney? Sum(
            this IEnumerable<UMoney?> source)
        {
            if (source == null)
            {
                throw SourceArgumentNullException();
            }

            var sum = (UMoney) 0;
            
            return source
                .Where(x => x.HasValue)
                .Aggregate(sum, (a, b) => a + b.Value);
        }
        
        public static UMoney Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, UMoney> selector)
        {
            return source
                .Select(selector)
                .Sum();
        }

        public static UMoney? Sum<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, UMoney?> selector)
        {
            return source
                .Select(selector)
                .Sum();
        }
    }
}