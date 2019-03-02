namespace Lykke.Numerics.Money.Tests
{
    public static class BigDecimalExtensions
    {
        public static BigDecimalAssertions Should(
            this Money instance)
        {
            return new BigDecimalAssertions(instance); 
        } 
    }
}