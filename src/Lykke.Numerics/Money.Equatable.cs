using System;
using JetBrains.Annotations;

namespace Lykke.Numerics
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
            return CompareTo(other) == 0;
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