namespace System.Numerics
{
    public partial struct BigDecimal
    {   
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
        
        public static explicit operator int(BigDecimal value)
        {
            return (int) (BigInteger) value;
        }
    }
}