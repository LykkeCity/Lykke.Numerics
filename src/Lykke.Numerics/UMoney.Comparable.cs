using System;
using JetBrains.Annotations;

namespace Lykke.Numerics
{
    public partial struct UMoney : IComparable, IComparable<UMoney>, IComparable<Money>
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
        /// <exception cref="ArgumentException">
        ///    obj is not UMoney.
        /// </exception>
        [Pure]
        public int CompareTo(
            object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case UMoney other:
                    return CompareTo(other);
                default:
                    throw new ArgumentException($"Object is not a {nameof(UMoney)}");
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
        ///    Compares this instance to a Money.
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
            Money other)
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
        public static UMoney Max(
            UMoney left,
            UMoney right)
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
        public static UMoney Min(
            UMoney left,
            UMoney right)
        {
            return left.CompareTo(right) <= 0 ? left : right;
        }
        
        #region Operators
        
        // UMoney 
        
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
        
        // Money 
        
        public static bool operator <(UMoney left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UMoney left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(UMoney left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UMoney left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }
        
        public static bool operator <(Money left, UMoney right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator <=(Money left, UMoney right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >(Money left, UMoney right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator >=(Money left, UMoney right)
        {
            return right.CompareTo(left) <= 0;
        }

        #endregion
    }
}