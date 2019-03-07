using System;
using JetBrains.Annotations;

namespace Lykke.Numerics.Money
{
    public partial struct Money : IEquatable<Money>
    {
        [Pure]
        public override bool Equals(
            object obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case Money other:
                    return Equals(other);
                default:
                    return false;
            }
        }

        /// <inheritdoc cref="IEquatable{Money}" />
        [Pure]
        public bool Equals(
            Money other)
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

        #region Operators
        
        // Money
        
        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !left.Equals(right);
        }
        
        #endregion
    }
}