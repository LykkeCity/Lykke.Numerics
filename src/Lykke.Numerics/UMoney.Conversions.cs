using System.Numerics;

namespace Lykke.Numerics
{
    public partial struct UMoney
    {
        /// <summary>
        ///    Round specified value to the specified scale and express it as a significand.
        /// </summary>
        public static UMoney Denominate(
            UMoney value,
            int scale)
        {
            return new UMoney
            (
                significand: Money.Round(value._value, scale).Significand,
                scale: 0
            );
        }
        
        #region Operators

        // To UMoney
        
        public static implicit operator UMoney(ulong value)
        {
            return Create(value, 0);
        }

        public static explicit operator UMoney(decimal value)
        {
            return Create(value);
        }
        
        public static explicit operator UMoney(BigInteger value)
        {
            return Create(value);
        }
        
        public static explicit operator UMoney(Money value)
        {
            return Create(value);
        }

        // From UMoney
        
        public static implicit operator Money(UMoney value)
        {
            return value._value;
        }

        public static explicit operator BigInteger(UMoney value)
        {
            return (BigInteger) value._value;
        }
        
        public static explicit operator byte(UMoney value)
        {
            return (byte) value._value;
        }

        public static explicit operator sbyte(UMoney value)
        {
            return (sbyte) value._value;
        }

        public static explicit operator short(UMoney value)
        {
            return (short) value._value;
        }

        public static explicit operator ushort(UMoney value)
        {
            return (ushort) value._value;
        }
        
        public static explicit operator int(UMoney value)
        {
            return (int) value._value;
        }
        
        public static explicit operator uint(UMoney value)
        {
            return (uint) value._value;
        }
        
        public static explicit operator long(UMoney value)
        {
            return (long) value._value;
        }
        
        public static explicit operator ulong(UMoney value)
        {
            return (ulong) value._value;
        }
        
        #endregion
    }
}