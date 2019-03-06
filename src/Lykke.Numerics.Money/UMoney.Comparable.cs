using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
    public partial struct UMoney : IComparable, IComparable<UMoney>, IComparable<BigInteger>, IComparable<decimal>
    {
        /// <summary>
        ///    Compares this instance to a specified object.
        /// </summary>
        /// <param name="obj">
        ///    The object to compare.
        /// </param>
        /// <returns>
        ///    Returns an integer that indicates whether the value of this instance is less than, equal to,
        ///    or greater than the value of the specified object. Less than zero if the current instance is less than obj.
        ///    Zero if the current instance equals obj. Greater than zero if the current instance is greater than obj,
        ///    or the obj parameter is null.
        /// </returns>
        [Pure]
        public int CompareTo(
            object obj)
        {
            if (obj is UMoney uMoney)
            {
                return CompareTo(uMoney);
            }
            else
            {
                return _value.CompareTo(obj);
            }
        }

        /// <summary>
        ///    Compares this instance to a second UMoney.
        /// </summary>
        /// <param name="other">
        ///    The object to compare.
        /// </param>
        /// <returns>
        ///    Returns an integer that indicates whether the value of this instance is less than, equal to, or greater
        ///    than the value of the specified object. Less than zero if the current instance is less than other.
        ///    Zero if the current instance equals other. Greater than zero if the current instance is greater than other.
        /// </returns>
        [Pure]
        public int CompareTo(
            UMoney other)
        {
            return _value.CompareTo(other._value);
        }
        
        /// <summary>
        ///    Compares this instance to a BigInteger.
        /// </summary>
        /// <param name="other">
        ///    The object to compare.
        /// </param>
        /// <returns>
        ///    Returns an integer that indicates whether the value of this instance is less than, equal to, or greater
        ///    than the value of the specified object. Less than zero if the current instance is less than other.
        ///    Zero if the current instance equals other. Greater than zero if the current instance is greater than other.
        /// </returns>
        [Pure]
        public int CompareTo(
            BigInteger other)
        {
            return _value.CompareTo(other);
        }
        
        /// <summary>
        ///    Compares this instance to a decimal.
        /// </summary>
        /// <param name="other">
        ///    The object to compare.
        /// </param>
        /// <returns>
        ///    Returns an integer that indicates whether the value of this instance is less than, equal to, or greater
        ///    than the value of the specified object. Less than zero if the current instance is less than other.
        ///    Zero if the current instance equals other. Greater than zero if the current instance is greater than other.
        /// </returns>
        [Pure]
        public int CompareTo(
            decimal other)
        {
            return _value.CompareTo(other);
        }
        
        /// <summary>
        ///    Returns the larger of two UMoney values.
        /// </summary>
        /// <param name="left">
        ///    The first value to compare.
        /// </param>
        /// <param name="right">
        ///    The second value to compare.
        /// </param>
        /// <returns>
        ///    The left or right parameter, whichever is larger.
        /// </returns>
        [Pure]
        public static Money Max(
            Money left,
            Money right)
        {
            return left.CompareTo(right) < 0 ? right : left;
        }

        /// <summary>
        ///    Returns the smaller of two UMoney values.
        /// </summary>
        /// <param name="left">
        ///    The first value to compare.
        /// </param>
        /// <param name="right">
        ///    The second value to compare.
        /// </param>
        /// <returns>
        ///    The left or right parameter, whichever is smaller.
        /// </returns>
        [Pure]
        public static Money Min(
            Money left,
            Money right)
        {
            return left.CompareTo(right) <= 0 ? left : right;
        }
        
        #region Operators
        
        // Money 
        
        public static bool operator <(UMoney left, UMoney right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UMoney left, UMoney right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(UMoney left, UMoney right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UMoney left, UMoney right)
        {
            return left.CompareTo(right) >= 0;
        }

        // BigInteger
        
        public static bool operator <(UMoney left, BigInteger right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UMoney left, BigInteger right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(UMoney left, BigInteger right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UMoney left, BigInteger right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(BigInteger left, UMoney right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator <=(BigInteger left, UMoney right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >(BigInteger left, UMoney right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator >=(BigInteger left, UMoney right)
        {
            return right.CompareTo(left) <= 0;
        }

        // Decimal
        
        public static bool operator <(UMoney left, decimal right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UMoney left, decimal right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(UMoney left, decimal right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UMoney left, decimal right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(decimal left, UMoney right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator <=(decimal left, UMoney right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >(decimal left, UMoney right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator >=(decimal left, UMoney right)
        {
            return right.CompareTo(left) <= 0;
        }

        #endregion
    }
}