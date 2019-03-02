using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
    public partial struct Money : IComparable, IComparable<Money>, IComparable<BigInteger>, IComparable<decimal>
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
            switch (obj)
            {
                case null:
                    return 1;
                case Money other:
                    return CompareTo(other);
                case BigInteger other:
                    return CompareTo(other);
                case decimal other:
                    return CompareTo(other);
                case byte other:
                    return CompareTo((BigInteger) other);
                case sbyte other:
                    return CompareTo((BigInteger) other);
                case int other:
                    return CompareTo((BigInteger) other);
                case long other:
                    return CompareTo((BigInteger) other);
                case short other:
                    return CompareTo((BigInteger) other);
                case uint other:
                    return CompareTo((BigInteger) other);
                case ulong other:
                    return CompareTo((BigInteger) other);
                case ushort other:
                    return CompareTo((BigInteger) other);
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), "Comparison with objects of specified type is not supported.");
            }
        }

        /// <summary>
        ///    Compares this instance to a second Money.
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
            if (_scale == other._scale)
            {
                return _significand.CompareTo(other._significand);
            }
            else
            {
                var (left, right) = EqualizeSignificands(this, other);

                return left.CompareTo(right);
            }
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
            return CompareTo(Money.Create(other, 0));
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
            return CompareTo(Money.Create(other));
        }

        /// <summary>
        ///    Compares two Money values and returns an integer that indicates whether the first value is less than,
        ///    equal to, or greater than the second value.
        /// </summary>
        /// <param name="left">
        ///    The first value to compare.
        /// </param>
        /// <param name="right">
        ///    The second value to compare.
        /// </param>
        /// <returns>
        ///    A signed integer that indicates the relative values of left and right. Less than zero, if left is less than
        ///    right. Zero if left equals right. Greater than zero if left is greater than right. Less than zero if the
        ///    current instance is less than other. Zero if the current instance equals other. Greater than zero if
        ///    the current instance is greater than other.
        /// </returns>
        [Pure]
        public static int Compare(
            Money left,
            Money right)
        {
            return left.CompareTo(right);
        }
        
        /// <summary>
        ///    Returns the larger of two Money values.
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
        ///    Returns the smaller of two Money values.
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
        
        public static bool operator <(Money left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Money left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Money left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Money left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        // BigInteger
        
        public static bool operator <(BigInteger left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(BigInteger left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(BigInteger left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(BigInteger left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(Money left, BigInteger right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator <=(Money left, BigInteger right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >(Money left, BigInteger right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator >=(Money left, BigInteger right)
        {
            return right.CompareTo(left) <= 0;
        }

        // Decimal
        
        public static bool operator <(decimal left, Money right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(decimal left, Money right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(decimal left, Money right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(decimal left, Money right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(Money left, decimal right)
        {
            return right.CompareTo(left) > 0;
        }

        public static bool operator <=(Money left, decimal right)
        {
            return right.CompareTo(left) >= 0;
        }

        public static bool operator >(Money left, decimal right)
        {
            return right.CompareTo(left) < 0;
        }

        public static bool operator >=(Money left, decimal right)
        {
            return right.CompareTo(left) <= 0;
        }

        #endregion
    }
}