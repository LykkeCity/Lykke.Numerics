using System.Numerics;

namespace Lykke.Numerics
{
    public partial struct Money
    {   
        #region Operators
        
        public static implicit operator Money(BigInteger value)
        {
            return Create(value, 0);
        }
        
        public static implicit operator Money(decimal value)
        {
            return Create(value);
        }

        public static explicit operator BigInteger(Money value)
        {
            return Truncate(value)._significand;
        }

        public static explicit operator byte(Money value)
        {
            return (byte) (BigInteger) value;
        }

        public static explicit operator sbyte(Money value)
        {
            return (sbyte) (BigInteger) value;
        }

        public static explicit operator short(Money value)
        {
            return (short) (BigInteger) value;
        }

        public static explicit operator ushort(Money value)
        {
            return (ushort) (BigInteger) value;
        }
        
        public static explicit operator int(Money value)
        {
            return (int) (BigInteger) value;
        }
        
        public static explicit operator uint(Money value)
        {
            return (uint) (BigInteger) value;
        }
        
        public static explicit operator long(Money value)
        {
            return (long) (BigInteger) value;
        }
        
        public static explicit operator ulong(Money value)
        {
            return (ulong) (BigInteger) value;
        }
        
        #endregion
    }
}