namespace System.Numerics
{
    public partial struct BigDecimal
    {   
        #region Operators
        
        public static implicit operator BigDecimal(BigInteger value)
        {
            return new BigDecimal(value);
        }
        
        public static implicit operator BigDecimal(decimal value)
        {
            return new BigDecimal(value);
        }

        public static explicit operator BigInteger(BigDecimal value)
        {
            return Truncate(value)._significand;
        }

        public static explicit operator byte(BigDecimal value)
        {
            return (byte) (BigInteger) value;
        }

        public static explicit operator sbyte(BigDecimal value)
        {
            return (sbyte) (BigInteger) value;
        }

        public static explicit operator short(BigDecimal value)
        {
            return (short) (BigInteger) value;
        }

        public static explicit operator ushort(BigDecimal value)
        {
            return (ushort) (BigInteger) value;
        }
        
        public static explicit operator int(BigDecimal value)
        {
            return (int) (BigInteger) value;
        }
        
        public static explicit operator uint(BigDecimal value)
        {
            return (uint) (BigInteger) value;
        }
        
        public static explicit operator long(BigDecimal value)
        {
            return (long) (BigInteger) value;
        }
        
        public static explicit operator ulong(BigDecimal value)
        {
            return (ulong) (BigInteger) value;
        }
        
        #endregion
    }
}