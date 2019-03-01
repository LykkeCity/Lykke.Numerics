using JetBrains.Annotations;

namespace System.Numerics
{
    public partial struct BigDecimal : IEquatable<BigDecimal>, IEquatable<BigInteger>, IEquatable<decimal>
    {
        [Pure]
        public override bool Equals(
            object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            else
            {
                switch (obj)
                {
                    case BigDecimal other:
                        return Equals(other);
                    case BigInteger other:
                        return Equals(other);
                    case decimal other:
                        return Equals(other);
                    case byte other:
                        return Equals((BigInteger) other);
                    case sbyte other:
                        return Equals((BigInteger) other);
                    case int other:
                        return Equals((BigInteger) other);
                    case long other:
                        return Equals((BigInteger) other);
                    case short other:
                        return Equals((BigInteger) other);
                    case uint other:
                        return Equals((BigInteger) other);
                    case ulong other:
                        return Equals((BigInteger) other);
                    case ushort other:
                        return Equals((BigInteger) other);
                    default:
                        return false;
                }
            }
        }

        /// <inheritdoc cref="IEquatable{BigDecimal}" />
        [Pure]
        public bool Equals(
            BigDecimal other)
        {
            if (_scale == other._scale)
            {
                return _significand == other._significand;
            }
            else
            {
                return EffectiveScale     == other.EffectiveScale 
                    && TrimmedSignificand == other.TrimmedSignificand;
            }
        }

        /// <inheritdoc cref="IEquatable{BigInteger}" />
        [Pure]
        public bool Equals(
            BigInteger other)
        {
            return Equals(new BigDecimal(other));
        }
        
        /// <inheritdoc cref="IEquatable{Decimal}" />
        [Pure]
        public bool Equals(
            decimal other)
        {
            return Equals(new BigDecimal(other));
        }
        
        #region Operators
        
        // BigDecimal
        
        public static bool operator ==(BigDecimal left, BigDecimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigDecimal left, BigDecimal right)
        {
            return !left.Equals(right);
        }
        
        // BigInteger
        
        public static bool operator ==(BigInteger left, BigDecimal right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(BigInteger left, BigDecimal right)
        {
            return !right.Equals(left);
        }
        
        public static bool operator ==(BigDecimal left, BigInteger right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigDecimal left, BigInteger right)
        {
            return !left.Equals(right);
        }
        
        // Decimal
        
        public static bool operator ==(decimal left, BigDecimal right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(decimal left, BigDecimal right)
        {
            return !right.Equals(left);
        }
        
        public static bool operator ==(BigDecimal left, decimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BigDecimal left, decimal right)
        {
            return !left.Equals(right);
        }
        
        #endregion
    }
}