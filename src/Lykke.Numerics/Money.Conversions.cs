using System.Numerics;

namespace Lykke.Numerics
{
    public partial struct Money
    {
        /// <summary>
        ///    Round specified value to the specified scale and express it as a significand.
        /// </summary>
        public static Money Denominate(
            Money value,
            int scale)
        {
            return new Money
            (
                significand: Round(value, scale).Significand,
                scale: 0
            );
        }
        
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

        public static explicit operator decimal(Money value)
        {
            //return (decimal) value._significand / (decimal) Pow10(value._scale);
            var decimalMaxValue = new BigInteger(decimal.MaxValue);
            var scaleValue = Pow10(value._scale);
            if (value._significand <= decimalMaxValue && scaleValue <= decimalMaxValue)
                return (decimal)value._significand / (decimal)scaleValue;

            var result = value._significand;
            var scale = value._scale;
            while (scale > 0 && result % 10 == 0)
            {
                result /= 10;
                scale -= 1;
            }

            scaleValue = Pow10(scale);
            if (result <= decimalMaxValue && scaleValue <= decimalMaxValue)
                return (decimal)result / (decimal)scaleValue;

            return decimal.Parse(value.ToString());
        }

        #endregion
    }
}