using System;
using System.Numerics;

namespace Lykke.Numerics.Money
{
    public partial struct UMoney
    {
        #region Operators

        public static implicit operator Money(UMoney value)
        {
            return value._value;
        }

        public static explicit operator UMoney(Money value)
        {
            if (value < 0m)
            {
                throw new InvalidCastException("Value should be greater or equal to zero.");
            }
            
            return new UMoney(value);
        }
        
        public static explicit operator BigInteger(UMoney value)
        {
            return (BigInteger) (Money) value;
        }
        
        public static explicit operator byte(UMoney value)
        {
            return (byte) (Money) value;
        }

        public static explicit operator sbyte(UMoney value)
        {
            return (sbyte) (Money) value;
        }

        public static explicit operator short(UMoney value)
        {
            return (short) (Money) value;
        }

        public static explicit operator ushort(UMoney value)
        {
            return (ushort) (Money) value;
        }
        
        public static explicit operator int(UMoney value)
        {
            return (int) (Money) value;
        }
        
        public static explicit operator uint(UMoney value)
        {
            return (uint) (Money) value;
        }
        
        public static explicit operator long(UMoney value)
        {
            return (long) (Money) value;
        }
        
        public static explicit operator ulong(UMoney value)
        {
            return (ulong) (Money) value;
        }
        
        #endregion
    }
}