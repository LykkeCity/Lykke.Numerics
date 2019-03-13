using System;
using JetBrains.Annotations;

namespace Lykke.Numerics
{
    public partial struct UMoney : IEquatable<UMoney>, IEquatable<Money>
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
        
        /// <inheritdoc cref="IEquatable{Money}" />
        [Pure]
        public bool Equals(
            Money other)
        {
            return _value.Equals(other);
        }

        #region Operators
        
        // UMoney
        
        public static bool operator ==(UMoney left, UMoney right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UMoney left, UMoney right)
        {
            return !left.Equals(right);
        }
        
        // Money
        
        public static bool operator ==(UMoney left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UMoney left, Money right)
        {
            return !left.Equals(right);
        }
        
        public static bool operator ==(Money left, UMoney right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(Money left, UMoney right)
        {
            return !right.Equals(left);
        }
        
        #endregion
    }
}