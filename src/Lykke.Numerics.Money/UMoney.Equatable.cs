using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
    public partial struct UMoney : IEquatable<UMoney>, IEquatable<BigInteger>, IEquatable<decimal>
    {
        [Pure]
        public override bool Equals(
            object obj)
        {
            switch (obj)
            {
                case UMoney uMoney:
                    return Equals(uMoney);
                default:
                    return _value.Equals(obj);
            }
        }
        
        /// <inheritdoc cref="IEquatable{UMoney}" />
        [Pure]
        public bool Equals(
            UMoney other)
        {
            return _value.Equals(other._value);
        }
        
        /// <inheritdoc cref="IEquatable{BigInteger}" />
        [Pure]
        public bool Equals(
            BigInteger other)
        {
            return _value.Equals(other);
        }

        /// <inheritdoc cref="IEquatable{Decimal}" />
        [Pure]
        public bool Equals(
            decimal other)
        {
            return _value.Equals(other);
        }

        #region Operators
        
        // Money
        
        public static bool operator ==(UMoney left, UMoney right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UMoney left, UMoney right)
        {
            return !left.Equals(right);
        }
        
        // BigInteger

        public static bool operator ==(UMoney left, BigInteger right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UMoney left, BigInteger right)
        {
            return !left.Equals(right);
        }
        
        public static bool operator ==(BigInteger left, UMoney right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(BigInteger left, UMoney right)
        {
            return !right.Equals(left);
        }
        
        // Decimal

        public static bool operator ==(UMoney left, decimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UMoney left, decimal right)
        {
            return !left.Equals(right);
        }
        
        public static bool operator ==(decimal left, UMoney right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(decimal left, UMoney right)
        {
            return !right.Equals(left);
        }
        
        #endregion
    }
}