namespace System.Numerics.Tests
{
    public static class BigDecimalExtensions
    {
        public static BigDecimalAssertions Should(
            this BigDecimal instance)
        {
            return new BigDecimalAssertions(instance); 
        } 
    }
}